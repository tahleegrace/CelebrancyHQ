using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Services.CeremonyTypes
{
    /// <summary>
    /// Provides helper functions for ceremony type permissions.
    /// </summary>
    public interface ICeremonyTypePermissionService
    {
        /// <summary>
        /// Checks whether the specified person can view the specified ceremony type.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="personId">The ID of the current user.</param>
        /// <returns>The current user and the specified ceremony type.</returns>
        Task<(User user, CeremonyType ceremonyType)> CheckCeremonyTypeIsAccessible(int ceremonyTypeId, int currentUserId);
    }
}