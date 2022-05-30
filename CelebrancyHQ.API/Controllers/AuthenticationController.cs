using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CelebrancyHQ.Models.DTOs.Authentication;
using CelebrancyHQ.Models.DTOs.Users;

namespace CelebrancyHQ.API.Controllers
{
    /// <summary>
    /// Provides CelebrancyHQ authentication functionality.
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// Logs into CelebrancyHQ.
        /// </summary>
        /// <param name="loginDetails">The login details of the user.</param>
        /// <returns>The details of the user who has logged in.</returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDetailsDTO loginDetails)
        {
            if (loginDetails == null)
            {
                return BadRequest();
            }

            // TODO: Check the database here.
            if (loginDetails.EmailAddress == "error@example.com")
            {
                return Unauthorized("Email address or password incorrect.");
            }
            else
            {
                return new UserDTO()
                {
                    Id = 1,
                    FirstName = "Tahlee-Joy",
                    LastName = "Grace",
                    BusinessName = "Q Celebrancy",
                    EmailAddress = "tahlee.grace@gmail.com"
                };
            }
        }
    }
}
