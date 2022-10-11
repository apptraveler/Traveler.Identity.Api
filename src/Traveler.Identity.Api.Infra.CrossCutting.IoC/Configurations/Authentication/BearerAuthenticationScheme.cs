using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.Net.Http.Headers;
using Traveler.Identity.Api.Application.Adapters.TokenManager;

namespace Traveler.Identity.Api.Infra.CrossCutting.IoC.Configurations.Authentication;

public class BearerAuthenticationScheme : AuthenticationHandler<BasicAuthenticationSchemeOptions>
{
    private readonly ITokenManager _tokenManager;

    public BearerAuthenticationScheme(
        IOptionsMonitor<BasicAuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock, ITokenManager tokenManager) : base(options, logger, encoder, clock)
    {
        _tokenManager = tokenManager;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        try
        {
            string authorization = Context.Request.Headers[HeaderNames.Authorization];

            var token = authorization["Bearer ".Length..].Trim();

            if (!_tokenManager.Validate(token))
            {
                return Task.FromResult(AuthenticateResult.Fail("Token inválido"));
            }

            var userId = _tokenManager.GetUserClaimFromToken(JwtRegisteredClaimNames.Sub, token);

            var claims = new List<Claim>
            {
                new(CustomClaims.UserId, userId)
            };

            var authenticationTicket = GetAuthenticationTicket(claims);

            return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
        }
        catch (Exception e)
        {
            Logger.LogCritical("Ocorreu um erro ao autenticara o token #### Exception: {0} ####", e.ToString());
            return Task.FromResult(AuthenticateResult.Fail("Token inválido"));
        }
    }

    private AuthenticationTicket GetAuthenticationTicket(IEnumerable<Claim> claims)
    {
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new System.Security.Principal.GenericPrincipal(identity, null);
        return new AuthenticationTicket(principal, Scheme.Name);
    }
}

public class BasicAuthenticationSchemeOptions : AuthenticationSchemeOptions
{
}
