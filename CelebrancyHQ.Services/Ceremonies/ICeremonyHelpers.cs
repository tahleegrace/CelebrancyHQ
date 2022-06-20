using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides helper functions for managing ceremonies.
    /// </summary>
    public interface ICeremonyHelpers
    {
        /// <summary>
        /// Checks whether the specified person can view the specified field in the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="field">The field.</param>
        /// <returns>Whether the specified person can view the specified field in the specified ceremony.</returns>
        Task CheckCanViewCeremony(int ceremonyId, int personId, string field);

        /// <summary>
        /// Checks whether the specified person can edit the specified field in the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="field">The field.</param>
        /// <returns>Whether the specified person can edit the specified field in the specified ceremony.</returns>
        Task CheckCanEditCeremony(int ceremonyId, int personId, string field);

        /// <summary>
        /// Gets the effective permissions for the specified person for the specified field in the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="field">The field.</param>
        /// <returns>The effective permissions for the specified person for the specified field in the specified ceremony.</returns>
        Task<CeremonyPermissionDTO> GetEffectivePermissionsForCeremony(int ceremonyId, int personId, string field);

        /// <summary>
        /// Checks whether the specified user can view the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The current user and the specified ceremony.</returns>
        Task<(User user, Ceremony ceremony)> CheckCeremonyIsAccessible(int ceremonyId, int currentUserId);
    }
}