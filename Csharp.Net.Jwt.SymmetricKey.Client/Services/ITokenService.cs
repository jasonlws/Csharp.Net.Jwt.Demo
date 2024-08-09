using Csharp.Net.Jwt.SymmetricKey.Client.Entities;

namespace Csharp.Net.Jwt.SymmetricKey.Client.Services
{
    public interface ITokenService
    {
        User DecodeToken(string token);
    }
}
