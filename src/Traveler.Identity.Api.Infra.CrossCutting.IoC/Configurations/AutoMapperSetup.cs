using System;
using Traveler.Identity.Api.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Traveler.Identity.Api.Infra.CrossCutting.IoC.Configurations;

public static class AutoMapperSetup
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(typeof(MappingProfile));
    }
}
