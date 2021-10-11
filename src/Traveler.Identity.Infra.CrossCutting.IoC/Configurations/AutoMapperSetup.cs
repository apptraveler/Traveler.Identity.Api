using System;
using Microsoft.Extensions.DependencyInjection;
using Traveler.Identity.Application.AutoMapper;

namespace Traveler.Identity.Infra.CrossCutting.IoC.Configurations
{
	public static class AutoMapperSetup
	{
		public static void AddAutoMapper(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddAutoMapper(typeof(MappingProfile));
		}
	}
}