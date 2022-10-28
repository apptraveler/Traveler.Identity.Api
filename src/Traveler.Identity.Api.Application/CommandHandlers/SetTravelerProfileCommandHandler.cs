using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Traveler.Identity.Api.Application.Commands;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;
using Traveler.Identity.Api.Domain.Exceptions;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Application.CommandHandlers;

public class SetTravelerProfileCommandHandler : CommandHandler<SetTravelerProfileCommand, Unit>
{
    private readonly ITravelerRepository _travelerRepository;
    private readonly ILogger<SetTravelerProfileCommandHandler> _logger;

    public SetTravelerProfileCommandHandler(
        IUnitOfWork uow,
        IMediator bus,
        INotificationHandler<ExceptionNotification> notifications,
        ITravelerRepository travelerRepository,
        ILogger<SetTravelerProfileCommandHandler> logger
    ) : base(uow,
        bus, notifications)
    {
        _travelerRepository = travelerRepository;
        _logger = logger;
    }

    public override async Task<Unit> Handle(SetTravelerProfileCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var traveler = await _travelerRepository.GetByIdAsync(request.UserId);

            if (traveler is null)
            {
                await Bus.Publish(new ExceptionNotification("104-TravelerNotFound", "Usuário não encontrado"), cancellationToken);
                return Unit.Value;
            }

            var locationTags = request.LocationTagsIds.Select(Enumeration.FromId<TravelerLocationTags>).ToArray();
            var averageSpend = Enumeration.FromId<TravelerAverageSpend>(request.AverageSpendId);

            traveler.SetTravelProfile(request.ProfileId, averageSpend, locationTags);

            if (await CommitAsync() is false)
            {
                await Bus.Publish(new ExceptionNotification("110-UnknownError", "Não foi possível completar a requisição"), cancellationToken);
                return Unit.Value;
            }

            return Unit.Value;
        }
        catch (Exception e)
        {
            _logger.LogCritical("Ocorreu um erro ao salvar o estilo de perfil do o usuário {0} #### Exception: {1} ####", request.UserId, e.ToString());
            await Bus.Publish(new ExceptionNotification("110-UnknownError", "Ocorreu um erro ao processar a requisição"), cancellationToken);
            return Unit.Value;
        }
    }
}
