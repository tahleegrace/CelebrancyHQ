using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony type meeting repository.
    /// </summary>
    public interface ICeremonyTypeMeetingRepository
    {
        /// <summary>
        /// Gets the ceremony type meeting with the specified ID.
        /// </summary>
        /// <param name="ceremonyTypeMeetingId">The ID of the ceremony type meeting.</param>
        /// <returns>The ceremony type meeting with the specified ID.</returns>
        Task<CeremonyTypeMeeting?> FindById(int ceremonyTypeMeetingId);
    }
}