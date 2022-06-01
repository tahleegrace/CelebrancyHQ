using System.Security.Claims;

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

        /// <summary>
        /// Gets the ID of the currently logged in user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The ID of the currently logged in user.</returns>
        int? GetCurrentUserId(ClaimsPrincipal user);
    }
}