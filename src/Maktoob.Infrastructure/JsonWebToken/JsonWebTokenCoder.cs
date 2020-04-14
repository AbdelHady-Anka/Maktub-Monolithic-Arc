using Maktoob.CrossCuttingConcerns.Settings;
using Maktoob.Domain.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Maktoob.Infrastructure.JsonWebToken
{
    public class JsonWebTokenCoder : IJsonWebTokenCoder
    {
        private readonly IOptions<JsonWebTokenSettings> _jsonWebTokenSettings;
        private readonly SigningCredentials _signingCredentials;
        public JsonWebTokenCoder(IOptions<JsonWebTokenSettings> jsonWebTokenSettings)
        {
            _jsonWebTokenSettings = jsonWebTokenSettings;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jsonWebTokenSettings.Value.Key));

            _signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        }

        public Dictionary<string, object> Decode(string token)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(token).Payload;
        }

        public string Encode(IList<Claim> claims)
        {
            if(claims == null)
            {
                claims = new List<Claim>();
            }

            claims.AddJti();

            var jwtSecuritToken = new JwtSecurityToken(_jsonWebTokenSettings.Value.Issuer, 
                _jsonWebTokenSettings.Value.Audience, 
                claims, 
                DateTime.UtcNow, 
                DateTime.UtcNow.Add(_jsonWebTokenSettings.Value.Expires), 
                _signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecuritToken);
        }
    }
}
