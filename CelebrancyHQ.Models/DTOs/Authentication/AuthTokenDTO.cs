using CelebrancyHQ.Models.DTOs.Users;

namespace CelebrancyHQ.Models.DTOs.Authentication
{
    // SOURCE: https://referbruv.com/blog/getting-started-with-securing-apis-using-jwt-bearer-authentication-hands-on/

    /// <summary>
    /// An auth token used for calling CelebrancyHQ APIs.
    /// </summary>
    public class AuthTokenDTO
    {
        public string Token { get; set; }

        public int ExpiresIn { get; set; }

        public UserDTO User { get; set; }
    }
}