using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Traveler.Identity.Application.Adapters.Authorization;
using Traveler.Identity.Domain.SeedWork;
using Traveler.Identity.Domain.Exceptions;
using Traveler.Identity.Application.Commands;
using Traveler.Identity.Application.DTOs;
using Traveler.Identity.Domain.Aggregates.JourneyerAggregate;

namespace Traveler.Identity.Application.CommandHandlers
{
    public class RegisterJourneyerCommandHandler : CommandHandler, IRequestHandler<RegisterJourneyerCommand, RegisterJourneyerResponse>
    {
        private readonly IAuthorizationService _authorizationService;

        public RegisterJourneyerCommandHandler(
            IUnitOfWork uow,
            IMediator bus,
            INotificationHandler<ExceptionNotification> notifications,
            IAuthorizationService authorizationService
        ) : base(uow, bus, notifications)
        {
            _authorizationService = authorizationService;
        }

        public async Task<RegisterJourneyerResponse> Handle(RegisterJourneyerCommand request, CancellationToken cancellationToken)
        {
            var journeyer = new Journeyer(request.Email, request.Username, request.Password);

            var token = _authorizationService.GenerateToken(journeyer);
            
            // add database

            if (await Commit()) return new RegisterJourneyerResponse(token);
            
            await Bus.Publish(new ExceptionNotification("001", "Não foi possível efetuar o cadastro"), cancellationToken);
            return default;
        }
    }
}