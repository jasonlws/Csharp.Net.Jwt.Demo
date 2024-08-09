using System.ComponentModel.DataAnnotations;

namespace Csharp.Net.Jwt.EcdsaKey.Server.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Token is required")]
        public string? Token { get; set; }
        [Required(ErrorMessage = "Id is required")]
        public string? Id { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string? Phone { get; set; }
    }
}
