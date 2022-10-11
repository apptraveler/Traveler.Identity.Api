﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Traveler.Identity.Api.Infra.CrossCutting.Environments.Configurations;
using Traveler.Identity.Api.Infra.Data.Mappings.Database;

namespace Traveler.Identity.Api.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    private readonly ApplicationConfiguration _applicationConfiguration;
    private readonly IMediator _bus;


    public ApplicationDbContext(ApplicationConfiguration applicationConfiguration)
    {
        _applicationConfiguration = applicationConfiguration;
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ApplicationConfiguration applicationConfiguration) : base(options)
    {
        _applicationConfiguration = applicationConfiguration;
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator, ApplicationConfiguration applicationConfiguration) : base(options)
    {
        _bus = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _applicationConfiguration = applicationConfiguration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(_applicationConfiguration.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TravelerMap());
        modelBuilder.ApplyConfiguration(new TravelerProfileMap());
        modelBuilder.ApplyConfiguration(new TravelerLocationMap());
        modelBuilder.ApplyConfiguration(new TravelerAverageSpendMap());
        modelBuilder.ApplyConfiguration(new TravelerLocationTagsMap());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        // Dispatch Domain Events collection.
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including
        // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions.
        // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers.
        await _bus.DispatchDomainEventsAsync(this);

        // After executing this line all the changes (from the Command Handler and Domain Event Handlers)
        // performed through the DbContext will be committed
        return await base.SaveChangesAsync(cancellationToken) > 0;
    }
}
