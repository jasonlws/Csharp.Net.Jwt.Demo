using Csharp.Net.Jwt.RsaKey.Server.Entities;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Csharp.Net.Jwt.RsaKey.Server.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly RsaSecurityKey _rsaKey;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            var rsa = RSA.Create();
            rsa.ImportFromPem(_configuration["RsaKey"]);
            _rsaKey = new RsaSecurityKey(rsa);
        }

        public string CreateToken(User user)
        {
            var claim = new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
                new Claim(ClaimTypes.Authentication, user.Id.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("Phone", user.Phone),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var creds = new SigningCredentials(_rsaKey, SecurityAlgorithms.RsaSha256);

            var jwt = new JwtSecurityToken(
                audience: _configuration["Audience"],
                issuer: _configuration["Issuer"],
                claims: claim,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMilliseconds(int.Parse(_configuration["TokenExpires"])),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(jwt);

        }

        public string RefreshToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuers = _configuration["Issuer"].Split(";").ToList(),
                ValidAudiences = _configuration["Audience"].Split(";").ToList(),
                IssuerSigningKey = _rsaKey,
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            var creds = new SigningCredentials(_rsaKey, SecurityAlgorithms.RsaSha256);

            var jwt = new JwtSecurityToken(
                issuer: _configuration["Issuer"],
                claims: principal.Claims.ToList(),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds
            );

            return tokenHandler.WriteToken(jwt);
        }
    }
}
