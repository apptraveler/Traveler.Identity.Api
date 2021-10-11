using System;
using Microsoft.Extensions.DependencyInjection;
using Traveler.Identity.Infra.Data.Context;

namespace Traveler.Identity.Infra.CrossCutting.IoC.Configurations
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