using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Traveler.Identity.Api.Application.Dtos;
using Traveler.Identity.Api.Application.Queries;
using Traveler.Identity.Api.Domain.Aggregates.TravelerProfileAggregate;
using Traveler.Identity.Api.Infra.CrossCutting.Environments.Configurations;

namespace Traveler.Identity.Api.Application.QueryHandlers;

public class GetAllTravelerProfilesQueryHandler : QueryHandler<GetAllTravelerProfilesQuery, IEnumerable<TravelerProfilesResponse>>
{
    private readonly ITravelerProfileRepository _travelerProfileRepository;
    private readonly ILogger<GetAllTravelerProfilesQueryHandler> _logger;

    public GetAllTravelerProfilesQueryHandler(
        ApplicationConfiguration applicationConfiguration,
        ITravelerProfileRepository travelerProfileRepository,
        ILogger<GetAllTravelerProfilesQueryHandler> logger
    ) : base(applicationConfiguration)
    {
        _travelerProfileRepository = travelerProfileRepository;
        _logger = logger;
    }

    public override async Task<IEnumerable<TravelerProfilesResponse>> Handle(GetAllTravelerProfilesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var profiles = await _travelerProfileRepository.GetAllAsync();

            if (profiles is null || !profiles.Any())
            {
                _logger.LogCritical("Não foi encontrado nenhum perfil");
                return default;
            }

            return profiles.Select(x => new TravelerProfilesResponse(x.Id, x.Name, x.Description)).ToList();
        }
        catch (Exception e)
        {
            _logger.LogCritical("Ocorreu um erro ao busar todos os perfis #### Exception: {0} ####", e.ToString());
            return default;
        }
    }
}
