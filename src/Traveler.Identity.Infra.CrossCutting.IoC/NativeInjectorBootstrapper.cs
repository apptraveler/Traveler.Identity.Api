using MediatR;
using System;
using FluentValidation;
using traveler.identity.api.domain.Exceptions;
using traveler.identity.api.application.Behaviour;
using Microsoft.Extensions.DependencyInjection;

namespace traveler.identity.api.infra.CrossCutting.IoC
{
	public static class NativeInjectorBootstrapper
	{
		public static void RegisterServices(IServiceCollection services)
		{
			RegisterData(services);
			RegisterMediatR(services);
		}

		private static void RegisterData(IServiceCollection services)
		{
			// here goes your repository injection
			// sample: services.AddScoped<IUserRepository, UserRepository>();
		}

		private static void RegisterMediatR(IServiceCollection services)
		{
			const string applicationAssemblyName = "Traveler.Identity.Application"; // use your project name
			var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);
			
			AssemblyScanner
				.FindValidatorsInAssembly(assembly)
				.ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));
			
			// injection for Mediator
			services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PipelineBehavior<,>));
			services.AddScoped<INotificationHandler<ExceptionNotification>, ExceptionNotificationHandler>();
		}
	}
}