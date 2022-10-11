using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Traveler.Identity.Api.Application.Adapters.TokenManager;
using Traveler.Identity.Api.Application.Commands;
using Traveler.Identity.Api.Application.Dtos;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.Exceptions;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Application.CommandHandlers;

public class LoginTravelerCommandHandler : CommandHandler<LoginTravelerCommand, LoginResponse>
{
    private readonly ITokenManager _tokenManager;
    private readonly ITravelerRepository _travelerRepository;
    private readonly ILogger<LoginTravelerCommand> _logger;

    public LoginTravelerCommandHandler(
        IUnitOfWork uow,
        IMediator bus,
        INotificationHandler<ExceptionNotification> notifications,
        ITravelerRepository travelerRepository,
        ITokenManager tokenManager,
        ILogger<LoginTravelerCommand> logger
    ) : base(uow,
        bus, notifications)
    {
        _travelerRepository = travelerRepository;
        _tokenManager = tokenManager;
        _logger = logger;
    }

    public override async Task<LoginResponse> Handle(LoginTravelerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var traveler = await _travelerRepository.GetByEmailAsync(request.Email);

            if (traveler is null)
            {
                await Bus.Publish(new ExceptionNotification("100-TravelerNotFound", "Usuário ou senha inválido"), cancellationToken);
                return default;
            }

            if (!traveler.CanLogin(request.Password))
            {
                await Bus.Publish(new ExceptionNotification("101-InvalidPassword", "Usuário ou senha inválido"), cancellationToken);
                return default;
            }

            var token = _tokenManager.Generate(traveler);

            return new LoginResponse(token, traveler.HasTravelProfile());
        }
        catch (Exception e)
        {
            await Bus.Publish(new ExceptionNotification("102-UnknownLoginError", "Não foi possível logar o usuário"), cancellationToken);
            _logger.LogCritical("Ocorreu um erro ao logar o usuário #### Exception: {0} ####", e.ToString());
            return default;
        }
    }
}
