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
        public async Task<ActionResult<UserDTO>> Login(LoginDetailsDTO loginDetails)
        {
            // TODO: Check the database here.
            // TODO: Check for invalid user details.
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
