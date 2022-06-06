using System.Security.Claims;

using AutoMapper;

using CelebrancyHQ.Models.DTOs.Authentication;
using CelebrancyHQ.Models.DTOs.Persons;
using CelebrancyHQ.Models.Exceptions.Authentication;
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
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of AuthenticationService.
        /// </summary>
        /// <param name="userRepository">The users repository.</param>
        /// <param name="tokenService">The token service.</param>
        /// <param name="mapper">The mapper.</param>
        public AuthenticationService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._tokenService = tokenService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Logs into CelebrancyHQ.
        /// </summary>
        /// <param name="loginDetails">The login details of the user.</param>
        /// <returns>The details of the user who has logged in.</returns>
        public async Task<AuthTokenDTO?> Login(LoginDetailsDTO loginDetails)
        {
            // TODO: Handle passwords securely here.

            // Make sure a user exists with the specified email address and password.
            var user = await this._userRepository.FindByEmailAddress(loginDetails.EmailAddress);

            if (user == null || user.PasswordHash != loginDetails.Password)
            {
                throw new LoginDetailsIncorrectException(loginDetails.EmailAddress);
            }

            var userDTO = this._mapper.Map<PersonDTO>(user.Person);
            userDTO.UserId = user.Id;

            return this._tokenService.Generate(userDTO);
        }

        /// <summary>
        /// Gets the ID of the currently logged in user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The ID of the currently logged in user.</returns>
        public int? GetCurrentUserId(ClaimsPrincipal user)
        {
            if (user == null)
            {
                return null;
            }

            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}