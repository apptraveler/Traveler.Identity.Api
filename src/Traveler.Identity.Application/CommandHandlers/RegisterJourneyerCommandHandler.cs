using System;
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
        private readonly IJourneyerRepository _journeyerRepository;

        public RegisterJourneyerCommandHandler(
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

        public async Task<RegisterJourneyerResponse> Handle(RegisterJourneyerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var journeyer = await _journeyerRepository.GetByEmailOrUsernameAsync(request.Email);

                if (journeyer is not null)
                {
                    await Bus.Publish(new ExceptionNotification("003", "Este email já está cadastrado"), cancellationToken);
                    return default;
                }

                journeyer = new Journeyer(request.Email, request.Username, request.Password, false);

                _journeyerRepository.Add(journeyer);

                if (!await Commit())
                {
                    await Bus.Publish(new ExceptionNotification("004", "Não foi possível efetuar o cadastro"), cancellationToken);
                    return default;
                }

                var token = _authorizationService.GenerateToken(journeyer);
                return new RegisterJourneyerResponse(token);
            }
            catch (Exception e)
            {
                await Bus.Publish(new ExceptionNotification("004", "Ocorreu um erro ao registrar um usuário"), cancellationToken);
                return default;
            }
        }
    }
}