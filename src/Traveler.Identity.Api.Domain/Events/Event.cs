using System;
using MediatR;

namespace Traveler.Identity.Api.Domain.Events;

public class Event : INotification
{
    public DateTime Timestamp { get; }

    protected Event()
    {
        Timestamp = DateTime.UtcNow;
    }
}
