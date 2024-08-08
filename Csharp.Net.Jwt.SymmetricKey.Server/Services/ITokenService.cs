using Csharp.Net.Jwt.SymmetricKey.Server.Entities;

namespace Csharp.Net.Jwt.SymmetricKey.Server.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
