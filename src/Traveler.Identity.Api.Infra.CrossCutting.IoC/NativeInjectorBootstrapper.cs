using System;
using Traveler.Identity.Api.Application.Behaviors;
using Traveler.Identity.Api.Domain.Exceptions;
using Traveler.Identity.Api.Infra.CrossCutting.Environments.Configurations;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Traveler.Identity.Api.Application.Adapters.TokenManager;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;
using Traveler.Identity.Api.Domain.Aggregates.TravelerProfileAggregate;
using Traveler.Identity.Api.Domain.SeedWork;
using Traveler.Identity.Api.Infra.CrossCutting.Identity;
using Traveler.Identity.Api.Infra.Data.Repositories;
using Traveler.Identity.Api.Infra.Data.UnitOfWork;

namespace Traveler.Identity.Api.Infra.CrossCutting.IoC;

public static class NativeInjectorBootstrapper
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        RegisterData(services);
        RegisterMediatR(services);
        RegisterEnvironments(services, configuration);
        RegisterIdentity(services);
    }

    private static void RegisterData(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<ITravelerRepository, TravelerRepository>();
        services.AddScoped<ITravelerLocationRepository, TravelerLocationRepository>();
        services.AddScoped<ITravelerProfileRepository, TravelerProfileRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void RegisterMediatR(IServiceCollection services)
    {
        const string applicationAssemblyName = "Traveler.Identity.Api.Application"; // use your project name
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
        services.AddSingleton(configuration.GetSection(nameof(ApplicationConfiguration)).Get<ApplicationConfiguration>());
        services.AddSingleton(configuration.GetSection(nameof(JwtConfiguration)).Get<JwtConfiguration>());
    }

    private static void RegisterIdentity(IServiceCollection services)
    {
        services.AddScoped<ITokenManager, TokenManager>();
    }
}
