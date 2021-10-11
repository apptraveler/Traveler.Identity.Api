using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Traveler.Identity.Domain.SeedWork;
using Traveler.Identity.Application.DTOs;
using Traveler.Identity.Domain.Exceptions;
using Traveler.Identity.Application.Commands;

namespace Traveler.Identity.Application.CommandHandlers
{
    public class JourneyerForgotPasswordCommandHandler : CommandHandler, IRequestHandler<JourneyerForgotPasswordCommand, JourneyerForgotPasswordResponse>
    {
        public JourneyerForgotPasswordCommandHandler(IUnitOfWork uow, IMediator bus, INotificationHandler<ExceptionNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public Task<JourneyerForgotPasswordResponse> Handle(JourneyerForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}