using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BasicFinancial.Data; 
using BasicFinancial.Services;
using BasicFinancial.Models.Request;
using BasicFinancial.Core.Services;
using BasicFinancial.Models.Response;

namespace BasicFinancial.Controllers.Mobile
{
    [ApiController]
    [Route("api/mobile/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        } 
        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest model)
        {
            var loginUser = await _userService.Login(model.Email,model.Password);
            if (loginUser == null)
                return BadRequest(new { message = "Username or Password Wrong " }); 
            var token = _tokenService.generateJwtToken(loginUser);
            var response = new AuthenticateResponse(loginUser, token);
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest model)
        {
            var response = await _userService.Register(model.MapToUser()); 
            if (response == null)
                return BadRequest(new { message = "Email already exist" });

            return Ok(response);
        }   
    }
}
