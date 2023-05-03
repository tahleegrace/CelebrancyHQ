using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.Exceptions.CeremonyTypes;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Repository.CeremonyTypes;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Services.CeremonyTypes
{
    /// <summary>
    /// Provides helper functions for ceremony type permissions.
    /// </summary>
    public class CeremonyTypePermissionService : ICeremonyTypePermissionService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICeremonyTypeRepository _ceremonyTypeRepository;

        /// <summary>
        /// Creats a new instance of CeremonyTypePermissionService.
        /// </summary>
        /// <param name="userRepository">The users repository.</param>
        /// <param name="ceremonyTypeRepository">The ceremony types repository.</param>
        public CeremonyTypePermissionService(IUserRepository userRepository, ICeremonyTypeRepository ceremonyTypeRepository)
        {
            this._userRepository = userRepository;
            this._ceremonyTypeRepository = ceremonyTypeRepository;
        }

        /// <summary>
        /// Checks whether the specified person can view the specified ceremony type.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="personId">The ID of the current user.</param>
        /// <returns>The current user and the specified ceremony type.</returns>
        public async Task<(User user, CeremonyType ceremonyType)> CheckCeremonyTypeIsAccessible(int ceremonyTypeId, int currentUserId)
        {
            // TODO: Check the user's permissions for the ceremony type here.
            // TODO: Allow a user to be a member of multiple organisations.

            var user = await this._userRepository.FindById(currentUserId);

            if (user == null)
            {
                throw new UserNotFoundException(currentUserId);
            }

            var ceremonyType = await this._ceremonyTypeRepository.FindById(ceremonyTypeId);

            if (ceremonyType == null)
            {
                throw new CeremonyTypeNotFoundException(ceremonyTypeId);
            }

            if (ceremonyType.OrganisationId != null && user.Person.OrganisationId != ceremonyType.OrganisationId)
            {
                throw new PersonCannotViewCeremonyTypeDetailsException(ceremonyTypeId);
            }

            return (user, ceremonyType);
        }
    }
}