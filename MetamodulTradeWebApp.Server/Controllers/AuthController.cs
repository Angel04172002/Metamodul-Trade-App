using MetamodulTradeWebApp.Server.Models;
using MetamodulTradeWebApp.Server.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAuthenticationService userService;

        public AuthController(IUserAuthenticationService userService)
        {
            this.userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel user)
        {
            var result = await userService.SignInUserAsync(user);

            if (result.Succeeded) 
            {
                return Ok();
            }

            return Unauthorized();
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegistrationViewModel user)
        {
            var userDto = await userService.RegisterUserAsync(user);

            return Ok();
        }
    }
}
