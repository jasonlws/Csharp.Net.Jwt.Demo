using System.ComponentModel.DataAnnotations;

namespace Csharp.Net.Jwt.SymmetricKey.Server.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AudienceType { get; set; }
        public string Token { get; set; }
    }
}
