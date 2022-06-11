using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony date repository.
    /// </summary>
    public interface ICeremonyDateRepository
    {
        /// <summary>
        /// Gets the dates for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The dates for the specified ceremony.</returns>
        Task<List<CeremonyDate>> GetCeremonyDates(int ceremonyId);
    }
}