using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traveler.Identity.Api.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Traveler.Identity.Api.Application.Commands;
using Traveler.Identity.Api.Application.Dtos;
using Traveler.Identity.Api.Application.Queries;
using Traveler.Identity.Api.Dtos;
using Traveler.Identity.Api.Dtos.Request;
using Traveler.Identity.Api.Infra.CrossCutting.IoC.Configurations.Authentication;

namespace Traveler.Identity.Api.Controllers.V1;

[ApiVersion("1")]
[ApiController]
[Authorize(AuthenticationSchemes = CustomAuthenticationSchemes.Bearer)]
[Route("[controller]/v{version:apiVersion}")]
public class TravelerController : BaseController
{
    private readonly IMediator _bus;

    public TravelerController(INotificationHandler<ExceptionNotification> notifications, IMediator bus) : base(notifications)
    {
        _bus = bus;
    }

    [HttpPut("profile")]
    [ProducesResponseType(typeof(Response<RegisterResponse>), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> SetTravelerProfile([FromBody] SetTravelerProfileRequest setTravelerProfileRequest)
    {
        var userId = GetUserClaim(CustomClaims.UserId);
        var command = new SetTravelerProfileCommand(
            Guid.Parse(userId),
            setTravelerProfileRequest.ProfileId,
            Convert.ToInt32(setTravelerProfileRequest.AverageSpendId),
            setTravelerProfileRequest.LocationTagsIds.Select(a => Convert.ToInt32(a)).ToArray()
        );
        await _bus.Send(command);
        return Response(NoContent());
    }

    [HttpGet("information")]
    [ProducesResponseType(typeof(Response<TravelerInformationResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserInformation()
    {
        var travelerId = GetUserClaim(CustomClaims.UserId);
        var query = new GetTravelerInformationByIdQuery(Guid.Parse(travelerId));
        var result = await _bus.Send(query);
        return Response(Ok(new Response<TravelerInformationResponse>(result)));
    }

    [HttpGet("profiles")]
    [ProducesResponseType(typeof(Response<IEnumerable<TravelerProfilesResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProfiles()
    {
        var query = new GetAllTravelerProfilesQuery();
        var result = await _bus.Send(query);
        return Response(Ok(new Response<IEnumerable<TravelerProfilesResponse>>(result)));
    }
}
