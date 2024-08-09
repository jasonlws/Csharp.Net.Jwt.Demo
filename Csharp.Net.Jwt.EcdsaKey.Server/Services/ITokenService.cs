using Csharp.Net.Jwt.EcdsaKey.Server.Entities;

namespace Csharp.Net.Jwt.EcdsaKey.Server.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
        string RefreshToken(string token);
    }
}
