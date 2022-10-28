using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Traveler.Identity.Api.Application.Dtos;
using Traveler.Identity.Api.Application.Queries;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;
using Traveler.Identity.Api.Domain.Exceptions;
using Traveler.Identity.Api.Domain.SeedWork;
using Traveler.Identity.Api.Infra.CrossCutting.Environments.Configurations;

namespace Traveler.Identity.Api.Application.QueryHandlers;

public class GetTravelerInformationByIdQueryHandler : QueryHandler<GetTravelerInformationByIdQuery, TravelerInformationResponse>
{
    private readonly ITravelerRepository _travelerRepository;
    private readonly ITravelerLocationRepository _travelerLocationRepository;
    private readonly IMediator _bus;
    private readonly ILogger<GetTravelerInformationByIdQueryHandler> _logger;

    public GetTravelerInformationByIdQueryHandler(ApplicationConfiguration applicationConfiguration, ITravelerRepository travelerRepository, ITravelerLocationRepository travelerLocationRepository, IMediator bus, ILogger<GetTravelerInformationByIdQueryHandler> logger) : base(applicationConfiguration)
    {
        _travelerRepository = travelerRepository;
        _travelerLocationRepository = travelerLocationRepository;
        _bus = bus;
        _logger = logger;
    }

    public override async Task<TravelerInformationResponse> Handle(GetTravelerInformationByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var traveler = await _travelerRepository.GetByIdAsync(request.TravelerId);

            if (traveler is null)
            {
                await _bus.Publish(new ExceptionNotification("120-UserNotFound", "Usuário não encontrado"), cancellationToken);
                return default;
            }

            var travelerLocations = await _travelerLocationRepository.GetAllByTravelerId(traveler.Id);
            var locationTags = travelerLocations.Select(travelerLocation => Enumeration.FromId<TravelerLocationTags>(travelerLocation.LocationId));

            return new TravelerInformationResponse(traveler.Email, traveler.FullName, traveler.Profile.Id, traveler.Profile.Name, traveler.Profile.Description, traveler.AverageSpend, locationTags.ToArray());
        }
        catch (Exception e)
        {
            await _bus.Publish(new ExceptionNotification("121-UnknownError", "Não foi possível buscar informações do usuário"), cancellationToken);
            _logger.LogCritical("Ocorreu um erro ao buscar informações do usuário #### Exception: {0} ####", e.ToString());
            return default;
        }
    }
}
