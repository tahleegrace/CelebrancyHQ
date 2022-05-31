using CelebrancyHQ.Models.DTOs.Authentication;
using CelebrancyHQ.Models.DTOs.Users;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Services.Authentication
{
    /// <summary>
    /// Provides authentication functions for CelebrancyHQ.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Creates a new instance of AuthenticationService.
        /// </summary>
        /// <param name="tokenService">The token service.</param>
        public AuthenticationService(IUserRepository userRepository, ITokenService tokenService)
        {
            this._userRepository = userRepository;
            this._tokenService = tokenService;
        }

        /// <summary>
        /// Logs into CelebrancyHQ.
        /// </summary>
        /// <param name="loginDetails">The login details of the user.</param>
        /// <returns>The details of the user who has logged in.</returns>
        public async Task<AuthTokenDTO?> Login(LoginDetailsDTO loginDetails)
        {
            // TODO: Handle passwords securely here.
            // TOOO: Return other details like a first name, last name and business name here.
            var user = await this._userRepository.FindByEmailAddress(loginDetails.EmailAddress);

            if (user == null || user.PasswordHash != loginDetails.Password)
            {
                return null;
            }

            var userDTO = new UserDTO()
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress
            };

            return this._tokenService.Generate(userDTO);
        }
    }
}