using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Csharp.Net.Jwt.SymmetricKey.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]

    [Authorize]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;

        public AccountController(ILogger<AccountController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            // Return the token
            return Ok("ok");
        }

    }
}
