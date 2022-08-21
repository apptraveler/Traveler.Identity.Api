using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Traveler.Identity.Api.Application.Dtos;
using Traveler.Identity.Api.Application.Queries;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.Exceptions;
using Traveler.Identity.Api.Infra.CrossCutting.Environments.Configurations;

namespace Traveler.Identity.Api.Application.QueryHandlers;

public class GetTravelerInformationByIdQueryHandler : QueryHandler<GetTravelerInformationByIdQuery, TravelerInformation>
{
    private readonly ITravelerRepository _travelerRepository;
    private readonly IMediator _bus;
    private readonly ILogger<GetTravelerInformationByIdQueryHandler> _logger;

    public GetTravelerInformationByIdQueryHandler(
        ApplicationConfiguration applicationConfiguration,
        ITravelerRepository travelerRepository,
        IMediator bus,
        ILogger<GetTravelerInformationByIdQueryHandler> logger
    ) : base(applicationConfiguration)
    {
        _travelerRepository = travelerRepository;
        _logger = logger;
        _bus = bus;
    }

    public override async Task<TravelerInformation> Handle(GetTravelerInformationByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var traveler = await _travelerRepository.GetByIdAsync(request.TravelerId);

            if (traveler is null)
            {
                await _bus.Publish(new ExceptionNotification("120-UserNotFound", "Usuário não encontrado"), cancellationToken);
                return default;
            }

            return new TravelerInformation(traveler.Email, traveler.FullName, traveler.BirthDate);
        }
        catch (Exception e)
        {
            await _bus.Publish(new ExceptionNotification("121-UnknownError", "Não foi possível buscar informações do usuário"), cancellationToken);
            _logger.LogCritical("Ocorreu um erro ao buscar informações do usuário #### Exception: {0} ####", e.ToString());
            return default;
        }
    }
}
