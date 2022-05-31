using CelebrancyHQ.Models.DTOs.Authentication;

namespace CelebrancyHQ.Services.Authentication
{
    /// <summary>
    /// A service that provides authentication functions.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Logs into CelebrancyHQ.
        /// </summary>
        /// <param name="loginDetails">The login details of the user.</param>
        /// <returns>The details of the user who has logged in.</returns>
        Task<AuthTokenDTO?> Login(LoginDetailsDTO loginDetails);
    }
}