using Csharp.Net.Jwt.SymmetricKey.Server.Entities;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Csharp.Net.Jwt.SymmetricKey.Server.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _symmetricKey;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricKey"]));
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

            var creds = new SigningCredentials(_symmetricKey, SecurityAlgorithms.HmacSha256Signature);

            var jwt = new JwtSecurityToken(
                audience: user.AudienceType,
                issuer: _configuration["Issuer"],
                claims: claim,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(jwt);

        }
    }
}
