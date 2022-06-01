using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

using CelebrancyHQ.Models.DTOs.Authentication;
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

            var result = await this._authenticationService.Login(loginDetails);

            if (result == null)
            {
                return Unauthorized("Email address or password invalid.");
            } 
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Test method for verifying an auth token. Do not have this in production.
        /// </summary>
        /// <returns>The string 'Hello World' and the user's ID.</returns>
        [HttpGet]
        [Authorize]
        [Route("test")]
        public async Task<ActionResult<string>> TestAuth()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var test = $"Hello World {userId}";

            return test;
        }
    }
}