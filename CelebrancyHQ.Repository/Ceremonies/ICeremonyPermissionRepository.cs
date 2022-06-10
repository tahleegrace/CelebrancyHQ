using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony permissions repository.
    /// </summary>
    public interface ICeremonyPermissionRepository
    {
        /// <summary>
        /// Gets the ceremony permissions for the specified ceremony, person and field.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="field">The name of the field.</param>
        /// <returns>The ceremony permissions matching the specified criteria.</returns>
        Task<List<CeremonyPermission>> GetCeremonyPermissionsForPerson(int ceremonyId, int personId, string field);
    }
}