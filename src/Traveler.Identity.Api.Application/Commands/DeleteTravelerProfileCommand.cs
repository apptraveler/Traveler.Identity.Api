using System;
using MediatR;

namespace Traveler.Identity.Api.Application.Commands;

public class DeleteTravelerProfileCommand : Command<Unit>
{
    public Guid UserId { get; }

    public DeleteTravelerProfileCommand(Guid userId)
    {
        UserId = userId;
    }

    public override bool IsValid()
    {
        return true;
    }
}
