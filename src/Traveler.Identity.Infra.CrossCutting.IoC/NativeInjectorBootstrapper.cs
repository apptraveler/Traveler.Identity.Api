using System;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Traveler.Identity.Domain.Exceptions;
using Traveler.Identity.Application.Behaviour;
using Microsoft.Extensions.DependencyInjection;
using Traveler.Identity.Domain.SeedWork;
using Traveler.Identity.Infra.CrossCutting.Authorization.JwtAuthorization;
using Traveler.Identity.Infra.CrossCutting.Environments.EnvironmentsConfigurations;
using Traveler.Identity.Infra.Data.UnitOfWork;
using IAuthorizationService = Traveler.Identity.Application.Adapters.Authorization.IAuthorizationService;

namespace Traveler.Identity.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterData(services);
            RegisterMediatR(services);
            RegisterEnvironments(services, configuration);
            RegisterAuthorizationService(services);
        }

        private static void RegisterData(IServiceCollection services)
        {
            // here goes your repository injection
            // sample: services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
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

        private static void RegisterEnvironments(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>());
        }

        private static void RegisterAuthorizationService(IServiceCollection services)
        {
            services.AddScoped<IAuthorizationService, JwtAuthorizationService>();
        }
    }
}