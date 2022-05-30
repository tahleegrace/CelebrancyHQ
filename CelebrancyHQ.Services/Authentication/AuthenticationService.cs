using CelebrancyHQ.Models.DTOs.Authentication;
using CelebrancyHQ.Models.DTOs.Users;

namespace CelebrancyHQ.Services.Authentication
{
    /// <summary>
    /// Provides authentication functions for CelebrancyHQ.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Creates a new instance of AuthenticationService.
        /// </summary>
        /// <param name="tokenService">The token service.</param>
        public AuthenticationService(ITokenService tokenService)
        {
            this._tokenService = tokenService;
        }

        /// <summary>
        /// Logs into CelebrancyHQ.
        /// </summary>
        /// <param name="loginDetails">The login details of the user.</param>
        /// <returns>The details of the user who has logged in.</returns>
        public AuthTokenDTO? Login(LoginDetailsDTO loginDetails)
        {
            // TODO: Check the database here.
            if (loginDetails.EmailAddress == "error@example.com")
            {
                return null;
            }
            else
            {
                var user = new UserDTO()
                {
                    Id = 1,
                    FirstName = "Tahlee-Joy",
                    LastName = "Grace",
                    BusinessName = "Q Celebrancy",
                    EmailAddress = "tahlee.grace@gmail.com"
                };

                return this._tokenService.Generate(user);
            }
        }
    }
}