using Csharp.Net.Jwt.RsaKey.Client.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Csharp.Net.Jwt.RsaKey.Client.Services
{
    public class TokenService: ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            // Check if the token is a valid JWT token
            if (!handler.CanReadToken(token))
            {
                Console.WriteLine("Invalid token format.");
                return null;
            }

            // Read the token
            var jwtToken = handler.ReadJwtToken(token);

            User user = new User();
            user.Id = Guid.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "Id")?.Value);
            user.UserName = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            user.Email = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            user.Phone = jwtToken.Claims.FirstOrDefault(c => c.Type == "Phone")?.Value;
            user.Token = token;

            return user;

        }
    }
}
