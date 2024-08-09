using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Csharp.Net.Jwt.EcdsaKey.Server.DTO
{
    public class UserCreateTokenDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        [DefaultValue("jasonlws")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DefaultValue("jason@jasonlws.com")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]

        [DefaultValue("123456789")]
        public string? Phone { get; set; }
    }
}
