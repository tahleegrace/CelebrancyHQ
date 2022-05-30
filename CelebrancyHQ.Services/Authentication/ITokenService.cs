using CelebrancyHQ.Models.DTOs.Authentication;
using CelebrancyHQ.Models.DTOs.Users;

namespace CelebrancyHQ.Services.Authentication
{
    // SOURCE: https://referbruv.com/blog/getting-started-with-securing-apis-using-jwt-bearer-authentication-hands-on/

    /// <summary>
    /// A service that generates an authentication token.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generates an authentication token.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An authentication token for the specified user.</returns>
        AuthTokenDTO Generate(UserDTO user);
    }
}