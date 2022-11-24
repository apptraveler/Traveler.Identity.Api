using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Traveler.Identity.Api.Application.Commands;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.Exceptions;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Application.CommandHandlers;

public class DeleteTravelerProfileCommandHandler : CommandHandler<DeleteTravelerProfileCommand, Unit>
{
    private readonly ITravelerRepository _travelerRepository;
    private readonly ILogger<DeleteTravelerProfileCommandHandler> _logger;

    public DeleteTravelerProfileCommandHandler(IUnitOfWork uow, IMediator bus,
        INotificationHandler<ExceptionNotification> notifications, ITravelerRepository travelerRepository,
        ILogger<DeleteTravelerProfileCommandHandler> logger) : base(uow, bus, notifications)
    {
        _travelerRepository = travelerRepository;
        _logger = logger;
    }

    public override async Task<Unit> Handle(DeleteTravelerProfileCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _travelerRepository.GetByIdAsync(request.UserId);

            if (user is null)
            {
                await Bus.Publish(new ExceptionNotification("400-UserNotFound", "Usuário não encontrado"),
                    cancellationToken);
                return Unit.Value;
            }

            _travelerRepository.Remove(user);

            if (await CommitAsync() is false)
            {
                await Bus.Publish(new ExceptionNotification("410-NotSave", "Erro ao deletar o usuário"),
                    cancellationToken);
                return Unit.Value;
            }

            return Unit.Value;
        }
        catch (Exception e)
        {
            await Bus.Publish(new ExceptionNotification("420-UnknownException", "Ocorreu um erro inesperado"),
                cancellationToken);
            _logger.LogCritical("Ocorreu um erro ao deletar o usuário #### Exception: {0} ####", e.ToString());
            return Unit.Value;
        }
    }
}
