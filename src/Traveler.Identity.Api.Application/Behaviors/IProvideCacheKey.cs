﻿namespace Traveler.Identity.Api.Application.Behaviors;

public interface IProvideCacheKey
{
    public string CacheKey { get; set; }
}
