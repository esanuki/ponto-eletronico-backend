using Api.Domain.Security;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api.Domain.Helpers
{
    public static class TokenHelpers
    {
        public static string CreateToken(
            ClaimsIdentity identity, 
            DateTime createTime, 
            DateTime expirationDate, 
            JwtSecurityTokenHandler handler,
            TokenConfigurations tokenConfigurations,
            SigningConfiguration signingConfiguration)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createTime,
                Expires = expirationDate
            });

            return handler.WriteToken(securityToken);
        }
    }
}
