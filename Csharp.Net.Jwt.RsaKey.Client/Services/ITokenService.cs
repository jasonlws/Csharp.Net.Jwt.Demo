using Csharp.Net.Jwt.RsaKey.Client.Entities;

namespace Csharp.Net.Jwt.RsaKey.Client.Services
{
    public interface ITokenService
    {
        User DecodeToken(string token);
    }
}
