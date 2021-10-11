using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using traveler.identity.api.application.Commands;
using traveler.identity.api.domain.Exceptions;

namespace traveler.identity.api.api.v1.Controllers.V1
{
    [ApiVersion("1")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IMediator _bus;

        public IdentityController(INotificationHandler<ExceptionNotification> notifications, IMediator bus) : base(notifications)
        {
            _bus = bus;
        }

        [HttpPost("signIn")]
        [ProducesResponseTypeAttribute(typeof(IEnumerable<string>), 200)]
        public async Task<IActionResult> SignInAsync()
        {
            var userSignInCommand = new UserSignInCommand("" , "");
            await _bus.Send(userSignInCommand);

            return Response(Ok());
        }
        
        [HttpPost("signUp")]
        [ProducesResponseTypeAttribute(typeof(IEnumerable<string>), 200)]
        public async Task<IActionResult> SignUpAsync()
        {
            var userSignUpCommand = new UserSignUpCommand("", "", "");
            await _bus.Send(userSignUpCommand);

            return Response(Ok());
        }
        
        [HttpPost("signUp")]
        [ProducesResponseTypeAttribute(typeof(IEnumerable<string>), 200)]
        public async Task<IActionResult> ForgotMyPassword()
        {
            var userForgotPasswordCommand = new UserForgotPasswordCommand("");
            await _bus.Send(userForgotPasswordCommand);

            return Response(Ok());
        }
    }
}