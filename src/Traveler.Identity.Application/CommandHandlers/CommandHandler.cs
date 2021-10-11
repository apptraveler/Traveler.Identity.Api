using System.Threading.Tasks;
using MediatR;
using Traveler.Identity.Application.Commands;
using Traveler.Identity.Domain.Exceptions;
using Traveler.Identity.Domain.SeedWork;

namespace Traveler.Identity.Application.CommandHandlers
{
    public abstract class CommandHandler
    {
        protected readonly IMediator Bus;
        private readonly IUnitOfWork _uow;
        private readonly ExceptionNotificationHandler _notifications;

        protected CommandHandler(IUnitOfWork uow, IMediator bus, INotificationHandler<ExceptionNotification> notifications)
        {
            _uow = uow;
            Bus = bus;
            _notifications = (ExceptionNotificationHandler)notifications;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.GetValidationResult().Errors)
            {
                Bus.Publish(new ExceptionNotification("001", error.ErrorMessage, error.PropertyName));
            }
        }

        public async Task<bool> Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (await _uow.Commit()) return true;

            await Bus.Publish(new ExceptionNotification("002", "We had a problem during saving your data."));

            return false;
        }
    }
}