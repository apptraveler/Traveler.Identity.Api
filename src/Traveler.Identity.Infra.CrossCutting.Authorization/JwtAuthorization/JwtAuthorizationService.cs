using System;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Traveler.Identity.Application.Adapters.Authorization;
using Traveler.Identity.Domain.Aggregates.JourneyerAggregate;
using Traveler.Identity.Infra.CrossCutting.Environments.EnvironmentsConfigurations;

namespace Traveler.Identity.Infra.CrossCutting.Authorization.JwtAuthorization
{
    public class JwtAuthorizationService : IAuthorizationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<JwtAuthorizationService> _logger;

        public JwtAuthorizationService(ILogger<JwtAuthorizationService> logger, JwtSettings jwtSettings)
        {
            _logger = logger;
            _jwtSettings = jwtSettings;
        }

        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
            return tokenValid.Claims;
        }

        public bool ValidateToken(string token)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
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
                _logger.LogError("Erro ao validar token JWT {0}", e);

                return false;
            }
        }

        public string GenerateToken(Journeyer journeyer)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Email, journeyer.Email),
                new(JwtRegisteredClaimNames.UniqueName, journeyer.Username),
                new("userId", journeyer.Id.ToString()),
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            
            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                signingCredentials: credentials
            );


            return tokenHandler.WriteToken(token);
        }
    }
}