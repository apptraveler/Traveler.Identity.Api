using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;
using Traveler.Identity.Api.Domain.Events;

namespace Traveler.Identity.Api.Application.EventHandlers.Domain;

public class SaveUserLocationsPreferencesDomainEventHandler : EventHandler<SaveUserLocationsPreferencesDomainEvent>
{
    private readonly ITravelerLocationRepository _locationRepository;
    private readonly ILogger<SaveUserLocationsPreferencesDomainEventHandler> _logger;

    public SaveUserLocationsPreferencesDomainEventHandler(ITravelerLocationRepository locationRepository, ILogger<SaveUserLocationsPreferencesDomainEventHandler> logger)
    {
        _locationRepository = locationRepository;
        _logger = logger;
    }

    public override Task Handle(SaveUserLocationsPreferencesDomainEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            foreach (var location in notification.Locations)
            {
                var travelerLocation = new TravelerLocation(notification.TravelerId, location.Id);
                _locationRepository.Add(travelerLocation);
            }

            return Task.CompletedTask;
        }
        catch (Exception e)
        {
            _logger.LogCritical("Ocorreu um erro ao salvar as localizações do usuário #### Exception: {0} ####", e.ToString());
            throw;
        }
    }
}
