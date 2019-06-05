using NetCore.AppServices.Interfaces;
using NetCore.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.AppServices.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _settings;
        

        public JwtService(JwtSettings settings)
        {
            _settings = settings;
        }

        public async Task<string> CreateJsonWebToken(Usuario user)
        {
            var identity = GetClaimsIdentity(user);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = identity,
                Issuer = _settings.Issuer,
                Audience = _settings.Audience,
                IssuedAt = _settings.IssuedAt,
                NotBefore = _settings.NotBefore,
                Expires = _settings.AccessTokenExpiration,
                SigningCredentials = _settings.SigningCredentials
            });

            var accessToken = handler.WriteToken(securityToken);

            return accessToken;
        }

        private static ClaimsIdentity GetClaimsIdentity(Usuario user)
        {
            var identity = new ClaimsIdentity
            (
                new GenericIdentity(user.Email),
                new []
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
                }
            );

            identity.AddClaim(new Claim("sid", user.Id.ToString()));

            return identity;
        }
    }
}
