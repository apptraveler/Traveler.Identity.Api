using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Traveler.Identity.Api.Domain.SeedWork;
using Traveler.Identity.Api.Domain.Exceptions;
using Traveler.Identity.Api.Application.Commands;

namespace Traveler.Identity.Api.Application.CommandHandlers;

public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : Command<TResponse>
{
    private readonly IUnitOfWork _uow;
    protected readonly IMediator Bus;
    private readonly ExceptionNotificationHandler _notifications;

    protected CommandHandler(IUnitOfWork uow, IMediator bus, INotificationHandler<ExceptionNotification> notifications)
    {
        _uow = uow;
        Bus = bus;
        _notifications = (ExceptionNotificationHandler) notifications;
    }

    protected void NotifyValidationErrors(TRequest message)
    {
        foreach (var error in message.GetValidationResult().Errors)
        {
            Bus.Publish(new ExceptionNotification("001", error.ErrorMessage, error.PropertyName));
        }
    }

    public async Task<bool> CommitAsync()
    {
        if (_notifications.HasNotifications()) return false;
        if (await _uow.CommitAsync()) return true;

        await Bus.Publish(new ExceptionNotification("002", "We had a problem during saving your data."));

        return false;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
