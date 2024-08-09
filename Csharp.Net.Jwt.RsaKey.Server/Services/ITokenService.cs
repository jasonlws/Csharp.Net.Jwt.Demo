using Csharp.Net.Jwt.RsaKey.Server.Entities;

namespace Csharp.Net.Jwt.RsaKey.Server.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
        string RefreshToken(string token);
    }
}
