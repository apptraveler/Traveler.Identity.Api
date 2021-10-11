using System;
using traveler.identity.api.infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace traveler.identity.api.infra.CrossCutting.IoC.Configurations
{
	public static class DatabaseSetup
	{
		public static void AddDatabaseSetup(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
		}
	}
}