using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartMonitoringSystem.Core.DTO;
using SmartMonitoringSystem.Core.Identity;
using SmartMonitoringSystem.Core.ServiceContracts;
using System.Security.Claims;

namespace SmartMonitoringSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly ILogger<LoginController> _logger;
        public LoginController(IJwtService jwtService, ILogger<LoginController> logger)
        {
            _jwtService = jwtService;
            _logger = logger;
        }
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<ApplicationUser>> PostLogin(LoginDto loginDTO)
        {
            _logger.LogInformation("Reached PostLogin method");
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(" | ", ModelState.Values.SelectMany(errors => errors.Errors).Select(e => e.ErrorMessage));
                return Problem(errorMessage);
            }
            else
            {
                var result = await _jwtService.LoginUser(loginDTO);
                if (result>=1)
                {
                    var authenticationResponse = _jwtService.CreateJWTToken(loginDTO);
                    _logger.LogInformation("JWT token produced successfully");
                    return Ok(authenticationResponse);
                }
                else
                {
                    _logger.LogInformation("JLogin failed due to incorrect credential");
                    return Problem("Invalid email or password!");
                }
            }
        }
        /// <summary>
        /// Generate new JWT Access token, if expired using refresh token
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        [HttpPost("generate-new-jwtToken")]
        public async Task<IActionResult> GenerateNewToken(TokenModel tokenModel)
        {
            if (tokenModel == null)
            {
                return BadRequest("Invalid client request");
            }

            ClaimsPrincipal?  claimsPrincipal = _jwtService.GetClaimsPrincipalJwtToken(tokenModel.Token);

            if (claimsPrincipal == null)
            {
                return BadRequest("Invalid jwt access token");
            }
            string? email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);
            TokenModel? applicationUser = await _jwtService.GetProfileByUserID(tokenModel.ID);
            if (applicationUser == null || applicationUser.RefreshToken != tokenModel.RefreshToken || applicationUser.RefreshTokenExpirationDatatime <= DateTime.Now)
            {
                return BadRequest("Invalid Refresh token");
            }
            var loginDto = new LoginDto { Email = applicationUser.Email!, Password = applicationUser.Password! };
            var authenticationUserResponse = _jwtService.CreateJWTToken(loginDto);
            applicationUser.RefreshToken = authenticationUserResponse.RefreshToken;
            applicationUser.RefreshTokenExpirationDatatime = authenticationUserResponse.RefreshTokenExpirationDatatime;
            return Ok(authenticationUserResponse);
        }
        /// <summary>
        /// Logout 
        /// </summary>
        /// <returns></returns>
        [HttpGet("logout")]
        public async Task<IActionResult> GetLogout()
        {
            _logger.LogInformation("Reached logout method");
            return NoContent();
        }

        [HttpGet("ForgotPassword")]
        public string ForgotPassword()
        {
            return string.Empty;
        }
        [HttpGet("MicrosoftLogin")]
        public string MicrosoftLogin()
        {
            return string.Empty;
        }
    }
}
