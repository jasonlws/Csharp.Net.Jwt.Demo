using System.ComponentModel.DataAnnotations;

namespace Csharp.Net.Jwt.EcdsaKey.Client.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
    }
}
