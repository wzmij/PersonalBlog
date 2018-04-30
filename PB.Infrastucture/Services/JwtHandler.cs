using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PB.Infrastucture.DTO;
using PB.Infrastucture.Settings;
using Microsoft.Extensions.Options;

namespace PB.Infrastucture.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _options;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly SecurityKey _securityKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtHeader _jwtHeader;

        public JwtHandler(JwtSettings settings)
        {
            _options = settings;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            _signingCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(_signingCredentials);
        }

        public JwtDTO Create(string email)
        {
            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddMinutes(_options.ExpireMinutes);
            var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            var iat = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
            var payload = new JwtPayload
            {
                {"sub", email},
                {"iss", _options.Issuer},
                {"iat", iat},
                {"exp", exp},
                {"unique_name", email},
            };
            var jwt = new JwtSecurityToken(_jwtHeader, payload);
            var token = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new JwtDTO
            {
                AccessToken = token,
                Expires = exp
            };
        }
    }
}