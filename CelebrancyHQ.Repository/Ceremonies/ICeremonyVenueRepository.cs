using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony venues repository.
    /// </summary>
    public interface ICeremonyVenueRepository
    {
        /// <summary>
        /// Gets the primary venue for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The primary venue for the specified ceremony.</returns>
        Task<Organisation?> GetPrimaryVenueForCeremony(int ceremonyId);

        /// <summary>
        /// Gets the primary venues for the specified ceremonies.
        /// </summary>
        /// <param name="ceremonyIds">The IDs of the ceremonies.</param>
        /// <returns>The primary venues for the specified ceremonies.</returns>
        Task<Dictionary<int, Organisation>> GetPrimaryVenuesForCeremonies(List<int> ceremonyIds);
    }
}