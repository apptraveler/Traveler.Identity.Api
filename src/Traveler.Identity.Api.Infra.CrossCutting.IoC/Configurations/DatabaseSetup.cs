using System;
using Traveler.Identity.Api.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Traveler.Identity.Api.Infra.CrossCutting.IoC.Configurations;

public static class DatabaseSetup
{
    public static void AddDatabaseSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
    }
}
