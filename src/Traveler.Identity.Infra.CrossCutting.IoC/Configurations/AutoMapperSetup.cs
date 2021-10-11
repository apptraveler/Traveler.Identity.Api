using System;
using AutoMapper;
using traveler.identity.api.application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace traveler.identity.api.infra.CrossCutting.IoC.Configurations
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