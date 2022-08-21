﻿using System;
using MediatR;

namespace Traveler.Identity.Api.Application.IntegrationEvents;

public abstract class IntegrationEvent : INotification
{
    public DateTime TimeStamp { get; }

    protected IntegrationEvent()
    {
        TimeStamp = DateTime.UtcNow;
    }
}
