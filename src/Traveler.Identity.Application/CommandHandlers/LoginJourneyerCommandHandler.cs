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
    public class LoginJourneyerCommandHandler : CommandHandler, IRequestHandler<LoginJourneyerCommand, LoginJourneyerResponse>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IJourneyerRepository _journeyerRepository;

        public LoginJourneyerCommandHandler(
            IUnitOfWork uow,
            IMediator bus,
            INotificationHandler<ExceptionNotification> notifications,
            IAuthorizationService authorizationService,
            IJourneyerRepository journeyerRepository
        ) : base(uow, bus, notifications)
        {
            _authorizationService = authorizationService;
            _journeyerRepository = journeyerRepository;
        }

        public async Task<LoginJourneyerResponse> Handle(LoginJourneyerCommand request, CancellationToken cancellationToken)
        {
            var journeyer = await _journeyerRepository.GetByEmailOrUsernameAsync(request.Email);

            if (journeyer is null)
            {
                await Bus.Publish(new ExceptionNotification("002", "Usuário não encontrado"), cancellationToken);
                return default;
            }

            var token = _authorizationService.GenerateToken(journeyer);

            return new LoginJourneyerResponse(token);
        }
    }
}