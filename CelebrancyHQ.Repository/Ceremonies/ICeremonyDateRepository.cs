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

        /// <summary>
        /// Gets the ceremony date with the specified ID.
        /// </summary>
        /// <param name="ceremonyDateId">The ID of the ceremony date.</param>
        /// <returns>The ceremony date with the specified ID.</returns>
        Task<CeremonyDate?> FindById(int ceremonyDateId);

        /// <summary>
        /// Updates the specified date.
        /// </summary>
        /// <param name="date">The date.</param>
        Task Update(CeremonyDate date);
    }
}