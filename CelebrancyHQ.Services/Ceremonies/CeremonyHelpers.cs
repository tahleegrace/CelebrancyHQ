using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides helper functions for managing ceremonies.
    /// </summary>
    public class CeremonyHelpers : ICeremonyHelpers
    {
        private readonly IUserRepository _userRepository;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly ICeremonyParticipantRepository _ceremonyParticipantRepository;
        private readonly ICeremonyPermissionRepository _ceremonyPermissionRepository;

        /// <summary>
        /// Creates a new instance of CeremonyHelpers.
        /// </summary>
        /// <param name="userRepository">The users repository.</param>
        /// <param name="ceremonyRepository">The ceremonies repository.</param>
        /// <param name="ceremonyParticipantRepository">The ceremony participants repository.</param>
        /// <param name="ceremonyPermissionRepository">The ceremony permissions repository.</param>
        public CeremonyHelpers(IUserRepository userRepository, ICeremonyRepository ceremonyRepository, 
            ICeremonyParticipantRepository ceremonyParticipantRepository, ICeremonyPermissionRepository ceremonyPermissionRepository)
        {
            this._userRepository = userRepository;
            this._ceremonyRepository = ceremonyRepository;
            this._ceremonyParticipantRepository = ceremonyParticipantRepository;
            this._ceremonyPermissionRepository = ceremonyPermissionRepository;
        }

        /// <summary>
        /// Checks whether the specified person can view the specified field in the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="field">The field.</param>
        /// <returns>Whether the specified person can view the specified field in the specified ceremony.</returns>
        public async Task CheckCanViewCeremony(int ceremonyId, int personId, string field)
        {
            var effectivePermissions = await GetEffectivePermissionsForCeremony(ceremonyId, personId, field);

            if (!effectivePermissions.CanView)
            {
                throw new PersonCannotViewCeremonyDetailsException(ceremonyId);
            }
        }

        /// <summary>
        /// Checks whether the specified person can edit the specified field in the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="field">The field.</param>
        /// <returns>Whether the specified person can edit the specified field in the specified ceremony.</returns>
        public async Task CheckCanEditCeremony(int ceremonyId, int personId, string field)
        {
            var effectivePermissions = await GetEffectivePermissionsForCeremony(ceremonyId, personId, field);

            if (!effectivePermissions.CanEdit)
            {
                throw new PersonCannotEditCeremonyException(ceremonyId);
            }
        }

        /// <summary>
        /// Gets the effective permissions for the specified person for the specified field in the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="field">The field.</param>
        /// <returns>The effective permissions for the specified person for the specified field in the specified ceremony.</returns>
        public async Task<CeremonyPermissionDTO> GetEffectivePermissionsForCeremony(int ceremonyId, int personId, string field)
        {
            var effectivePermissions = new CeremonyPermissionDTO()
            {
                Field = field
            };

            var permissions = await this._ceremonyPermissionRepository.GetCeremonyPermissionsForPerson(ceremonyId, personId, field);

            foreach (CeremonyPermission ceremonyPermission in permissions)
            {
                if (ceremonyPermission.CanView)
                {
                    effectivePermissions.CanView = true;
                }

                if (ceremonyPermission.CanEdit)
                {
                    effectivePermissions.CanEdit = true;
                }

                if (ceremonyPermission.CanEditWithApproval)
                {
                    effectivePermissions.CanEditWithApproval = true;
                }

                if (ceremonyPermission.IsApprover)
                {
                    effectivePermissions.IsApprover = true;
                }

                if (ceremonyPermission.CanViewHistory)
                {
                    effectivePermissions.CanViewHistory = true;
                }
            }

            return effectivePermissions;
        }

        /// <summary>
        /// Checks whether the specified user can view the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The current user and the specified ceremony.</returns>
        public async Task<(User user, Ceremony ceremony)> CheckCeremonyIsAccessible(int ceremonyId, int currentUserId)
        {
            var user = await this._userRepository.FindById(currentUserId);

            if (user == null)
            {
                throw new UserNotFoundException(currentUserId);
            }

            var ceremony = await this._ceremonyRepository.FindById(ceremonyId);

            if (ceremony == null)
            {
                throw new CeremonyNotFoundException(ceremonyId);
            }

            // Make sure the current user is a participant in the ceremony.
            var canAccessCeremony = await this._ceremonyParticipantRepository.PersonIsCeremonyParticipant(user.PersonId, ceremonyId);

            if (!canAccessCeremony)
            {
                throw new PersonNotCeremonyParticipantException(ceremonyId);
            }

            return (user, ceremony);
        }
    }
}