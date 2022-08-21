using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Traveler.Identity.Api.Application.Adapters.TokenManager;
using Traveler.Identity.Api.Infra.CrossCutting.Environments.Configurations;

namespace Traveler.Identity.Api.Infra.CrossCutting.Identity;

public class TokenManager : ITokenManager
{
    private readonly JwtConfiguration _jwtConfiguration;

    public TokenManager(JwtConfiguration jwtConfiguration)
    {
        _jwtConfiguration = jwtConfiguration;
    }

    public string GetUserClaimFromToken(string claim, string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        if (!tokenHandler.CanReadToken(token))
        {
            return string.Empty;
        }

        var readToken = tokenHandler.ReadJwtToken(token);
        var claimResult = readToken.Payload[claim].ToString();

        return claimResult ?? string.Empty;
    }


    public string Generate(Domain.Aggregates.TravelerAggregate.Traveler traveler)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtConfiguration.Secret);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, traveler.Id.ToString())
        };

        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            _jwtConfiguration.Issuer,
            _jwtConfiguration.Audience,
            claims,
            signingCredentials: credentials
        );

        return tokenHandler.WriteToken(token);
    }

    public bool Validate(string token)
    {
        var key = Encoding.ASCII.GetBytes(_jwtConfiguration.Secret);
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidIssuer = _jwtConfiguration.Issuer,
            ValidAudience = _jwtConfiguration.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        try
        {
            jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
