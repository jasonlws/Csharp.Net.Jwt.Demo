using Csharp.Net.Jwt.SymmetricKey.Server.Entities;
using Csharp.Net.Jwt.SymmetricKey.Server.Services;
using Csharp.Net.Jwt.SymmetricKey.Server.DTO;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Csharp.Net.Jwt.SymmetricKey.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AccountController(ILogger<AccountController> logger, IConfiguration configuration, ITokenService tokenService)
        {
            _logger = logger;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            var user = new User();
            user.UserName = userDTO.UserName;
            user.Email = userDTO.Email;
            user.Phone = userDTO.Phone;
            user.AudienceType = userDTO.AudienceType;
            user.Id = Guid.NewGuid();
            user.Token = _tokenService.CreateToken(user);


            // Return the token
            return Ok(user);
        }

    }
}
