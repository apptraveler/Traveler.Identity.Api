using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Traveler.Identity.Api.DTOs;
using Traveler.Identity.Application.Commands;
using Traveler.Identity.Application.DTOs;
using Traveler.Identity.Domain.Exceptions;

namespace Traveler.Identity.Api.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IMediator _bus;

        public AuthenticationController(INotificationHandler<ExceptionNotification> notifications, IMediator bus) : base(notifications)
        {
            _bus = bus;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public async Task<IActionResult> JourneyerLoginAsync(LoginJourneyerCommand loginJourneyerCommand)
        {
            var loginJourneyerResponse = await _bus.Send(loginJourneyerCommand);

            return Response(Ok(new SuccessResponseDto<LoginJourneyerResponse>(loginJourneyerResponse)));
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public async Task<IActionResult> JourneyerRegisterAsync(RegisterJourneyerCommand registerJourneyerCommand)
        {
            var registerJourneyerResponse = await _bus.Send(registerJourneyerCommand);

            return Response(Ok(new SuccessResponseDto<RegisterJourneyerResponse>(registerJourneyerResponse)));
        }

        [HttpPost("forgot-password")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public async Task<IActionResult> ForgotMyPassword(JourneyerForgotPasswordCommand journeyerForgotPasswordCommand)
        {
            var journeyerForgotPasswordResponse = await _bus.Send(journeyerForgotPasswordCommand);

            return Response(Ok(new SuccessResponseDto<JourneyerForgotPasswordResponse>(journeyerForgotPasswordResponse)));
        }
    }
}