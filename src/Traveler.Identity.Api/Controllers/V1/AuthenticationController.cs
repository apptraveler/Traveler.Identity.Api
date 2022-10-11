using System.Threading.Tasks;
using Traveler.Identity.Api.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Traveler.Identity.Api.Application.Commands;
using Traveler.Identity.Api.Application.Dtos;
using Traveler.Identity.Api.Dtos;

namespace Traveler.Identity.Api.Controllers.V1;

[ApiVersion("1")]
[ApiController]
public class AuthenticationController : BaseController
{
    private readonly IMediator _bus;

    public AuthenticationController(INotificationHandler<ExceptionNotification> notifications, IMediator bus) : base(notifications)
    {
        _bus = bus;
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(Response<RegisterResponse>), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterTravelerCommand registerTravelerCommand)
    {
        var result = await _bus.Send(registerTravelerCommand);
        return Response(Created(Request.Path.ToUriComponent(), new Response<RegisterResponse>(result)));
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(Response<LoginResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginUser([FromBody] LoginTravelerCommand loginTravelerCommand)
    {
        var result = await _bus.Send(loginTravelerCommand);
        return Response(Ok(new Response<LoginResponse>(result)));
    }
}
