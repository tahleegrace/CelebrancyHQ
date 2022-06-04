using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremonies repository.
    /// </summary>
    public interface ICeremonyRepository
    {
        /// <summary>
        /// Gets all of the ceremonies for the specified person with the specified participant types between the specified dates.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="participantTypeIds">The ID of the participant types.</param>
        /// <param name="from">The from date.</param>
        /// <param name="to">The to date.</param>
        /// <returns>The ceremonies matching the specified criteria.</returns>
        Task<List<Ceremony>> GetAll(int personId, List<int> participantTypeIds, DateTime? from, DateTime? to);
    }
}