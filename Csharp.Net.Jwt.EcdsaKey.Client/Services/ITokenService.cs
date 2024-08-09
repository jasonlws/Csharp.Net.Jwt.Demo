using Csharp.Net.Jwt.EcdsaKey.Client.Entities;

namespace Csharp.Net.Jwt.EcdsaKey.Client.Services
{
    public interface ITokenService
    {
        User DecodeToken(string token);
    }
}
