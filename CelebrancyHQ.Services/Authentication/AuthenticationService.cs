using System.Security.Claims;

using CelebrancyHQ.Models.DTOs.Authentication;
using CelebrancyHQ.Models.DTOs.Users;
using CelebrancyHQ.Repository.Organisations;
using CelebrancyHQ.Repository.Persons;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Services.Authentication
{
    /// <summary>
    /// Provides authentication functions for CelebrancyHQ.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IOrganisationRepository _organisationRepository;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Creates a new instance of AuthenticationService.
        /// </summary>
        /// <param name="userRepository">The users repository.</param>
        /// <param name="personRepository">The persons repository.</param>
        /// <param name="organisationRepository">The organisations repository.</param>
        /// <param name="tokenService">The token service.</param>
        public AuthenticationService(IUserRepository userRepository, IPersonRepository personRepository, IOrganisationRepository organisationRepository, 
            ITokenService tokenService)
        {
            this._userRepository = userRepository;
            this._personRepository = personRepository;
            this._organisationRepository = organisationRepository;
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

            // Make sure a user exists with the specified email address and password.
            var user = await this._userRepository.FindByEmailAddress(loginDetails.EmailAddress);

            if (user == null || user.PasswordHash != loginDetails.Password)
            {
                return null;
            }

            // Find the person for the specified user.
            var person = await this._personRepository.FindById(user.PersonId);

            // Find the organisation for the specified user.
            var organisation = person.OrganisationId != null ? await this._organisationRepository.FindById(person.OrganisationId.Value) : null; 

            var userDTO = new UserDTO()
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                FirstName = person.FirstName,
                LastName = person.LastName,
                BusinessName = organisation?.Name
            };

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