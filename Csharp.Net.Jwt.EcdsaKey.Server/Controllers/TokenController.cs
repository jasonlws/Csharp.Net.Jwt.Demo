using Csharp.Net.Jwt.EcdsaKey.Server.Entities;
using Csharp.Net.Jwt.EcdsaKey.Server.Services;
using Csharp.Net.Jwt.EcdsaKey.Server.DTO;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Csharp.Net.Jwt.EcdsaKey.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {

        private readonly ILogger<TokenController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public TokenController(ILogger<TokenController> logger, IConfiguration configuration, ITokenService tokenService)
        {
            _logger = logger;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("create-token")]
        public async Task<ActionResult<UserDTO>> CreateToken([FromBody] UserCreateTokenDTO userCreateTokenDTO)
        {
            var user = new User();
            user.UserName = userCreateTokenDTO.UserName;
            user.Email = userCreateTokenDTO.Email;
            user.Phone = userCreateTokenDTO.Phone;
            user.Id = Guid.NewGuid();
            user.Token = _tokenService.CreateToken(user);

            return Ok(new UserDTO()
            {
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                Id = user.Id.ToString(),
                Token = user.Token
            });
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<UserDTO>> RefreshToken([FromBody] UserRefreshTokenDTO userRefreshDTO)
        {
            var user = new User();
            user.UserName = userRefreshDTO.UserName;
            user.Email = userRefreshDTO.Email;
            user.Phone = userRefreshDTO.Phone;
            user.Id = Guid.Parse(userRefreshDTO.Id);
            user.Token = _tokenService.RefreshToken(userRefreshDTO.Token);

            return Ok(new UserDTO()
            {
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                Id = user.Id.ToString(),
                Token = user.Token
            });
        }
    }
}
