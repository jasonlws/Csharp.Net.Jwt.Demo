using Microsoft.AspNetCore.Identity.Data;
using Csharp.Net.Jwt.RsaKey.Client.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Csharp.Net.Jwt.RsaKey.Client.Entities;
using Csharp.Net.Jwt.RsaKey.Client.DTO;

namespace Csharp.Net.Jwt.RsaKey.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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

        private string ExtractJwtTokenFromHeader()
        {
            // Retrieve the Authorization header value
            var authHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            // Check if the header is present and starts with "Bearer "
            if (authHeader != null && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                // Extract the token from the "Bearer " prefix
                return authHeader.Substring("Bearer ".Length).Trim();
            }

            return null;
        }

        [HttpGet("validate-token")]
        public async Task<ActionResult<UserDTO>> ValidateToken()
        {
            var token = ExtractJwtTokenFromHeader();

            User user = _tokenService.DecodeToken(token);

            if (user == null)
            {
                return BadRequest("Token validation failed: The provided token is invalid or expired. Please ensure you are using a valid token and try again.");
            }
            else
            {
                return Ok(new UserDTO()
                {
                    Token = user.Token,
                    Id = user.Id.ToString(),
                    UserName = user.UserName,
                    Email = user.Email,
                    Phone = user.Phone
                });
            }
            
        }

    }
}
