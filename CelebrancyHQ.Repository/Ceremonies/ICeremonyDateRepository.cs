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
        /// Gets the ceremony date for the specified ceremony with the specified code.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="code">The code.</param>
        /// <returns>The ceremony date with the specified code.</returns>
        Task<CeremonyDate?> FindByCode(int ceremonyId, string code);

        /// <summary>
        /// Creates a new ceremony date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The newly created ceremony date.</returns>
        Task<CeremonyDate> Create(CeremonyDate date);

        /// <summary>
        /// Updates the specified date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>The newly updated date.</returns>
        Task<CeremonyDate> Update(CeremonyDate date);
    }
}