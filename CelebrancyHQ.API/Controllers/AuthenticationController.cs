using Microsoft.AspNetCore.Mvc;

using CelebrancyHQ.Models.DTOs.Authentication;
using CelebrancyHQ.Models.DTOs.Users;
using CelebrancyHQ.Services.Authentication;

namespace CelebrancyHQ.API.Controllers
{
    /// <summary>
    /// Provides CelebrancyHQ authentication functionality.
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        /// <summary>
        /// Creates a new instance of AuthenticationController.
        /// </summary>
        /// <param name="tokenService">The token service.</param>
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        /// <summary>
        /// Logs into CelebrancyHQ.
        /// </summary>
        /// <param name="loginDetails">The login details of the user.</param>
        /// <returns>The details of the user who has logged in.</returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthTokenDTO>> Login(LoginDetailsDTO loginDetails)
        {
            if (loginDetails == null)
            {
                return BadRequest();
            }

            var result = this._authenticationService.Login(loginDetails);

            if (result == null)
            {
                return Unauthorized("Email address or password invalid.");
            } 
            else
            {
                return result;
            }
        }
    }
}