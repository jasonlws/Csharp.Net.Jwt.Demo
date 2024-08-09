using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Csharp.Net.Jwt.RsaKey.Server.DTO
{
    public class UserRefreshTokenDTO
    {

        [Required(ErrorMessage = "Token is required")]
        [DefaultValue("")]
        public string? Token { get; set; }
        [Required(ErrorMessage = "Id is required")]
        [DefaultValue("")]
        public string? Id { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        [DefaultValue("")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DefaultValue("")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [DefaultValue("")]
        public string? Phone { get; set; }
        
    }
}
