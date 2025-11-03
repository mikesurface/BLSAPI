using CPIService.Core;
using CPIService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        #region Constructor and Globals

        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        #endregion

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Replace with real user validation (e.g., database lookup)
            //if (model.Username == "admin" && model.Password == "password")
            //{
            // for now, let all through...
                var token = _authService.GenerateToken(model.Username);
                return Ok(new { token });
            //}

            //return Unauthorized("Invalid credentials");
        }
    }

}
