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

public class RegisterTravelerCommandHandler : CommandHandler<RegisterTravelerCommand, RegisterResponse>
{
    private readonly ITravelerRepository _travelerRepository;
    private readonly ITokenManager _tokenManager;
    private readonly ILogger<RegisterTravelerCommandHandler> _logger;

    public RegisterTravelerCommandHandler(
        IUnitOfWork uow,
        IMediator bus,
        INotificationHandler<ExceptionNotification> notifications,
        ITravelerRepository travelerRepository,
        ITokenManager tokenManager,
        ILogger<RegisterTravelerCommandHandler> logger
    ) : base(uow, bus, notifications)
    {
        _travelerRepository = travelerRepository;
        _tokenManager = tokenManager;
        _logger = logger;
    }

    public override async Task<RegisterResponse> Handle(RegisterTravelerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var travelerFound = await _travelerRepository.GetByEmailAsync(request.Email);

            if (travelerFound is not null)
            {
                await Bus.Publish(new ExceptionNotification("110-UserAlreadyRegistered", "Usuário já registrado"), cancellationToken);
                return default;
            }

            var traveler = new Domain.Aggregates.TravelerAggregate.Traveler(request.Email, request.FullName, request.Password);

            _travelerRepository.Add(traveler);

            if (await CommitAsync() is false)
            {
                await Bus.Publish(new ExceptionNotification("111-ErrorOnSavingRegistration", "Não foi possível efetuar o cadastro"), cancellationToken);
                return default;
            }

            var token = _tokenManager.Generate(traveler);

            return new RegisterResponse(token);
        }
        catch (Exception e)
        {
            await Bus.Publish(new ExceptionNotification("113-UnknownRegisterError", "Não foi possível cadastrar o usuário"), cancellationToken);
            _logger.LogCritical("Ocorreu um erro ao cadastrar o usuário #### Exception: {0} ####", e.ToString());
            return default;
        }
    }
}
