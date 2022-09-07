using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony meeting repository.
    /// </summary>
    public interface ICeremonyMeetingRepository
    {
        /// <summary>
        /// Gets the ceremony meeting with the specified ID.
        /// </summary>
        /// <param name="ceremonyMeetingId">The ID of the ceremony meeting.</param>
        /// <returns>The ceremony meeting with the specified ID.</returns>
        Task<CeremonyMeeting?> FindById(int ceremonyMeetingId);

        /// <summary>
        /// Gets the meetings for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The meetings for the specified ceremony.</returns>
        Task<List<CeremonyMeeting>> GetCeremonyMeetings(int ceremonyId);

        /// <summary>
        /// Creates a new ceremony meeting.
        /// </summary>
        /// <param name="meeting">The meeting.</param>
        /// <returns>The newly created ceremony meeting.</returns>
        Task<CeremonyMeeting> Create(CeremonyMeeting meeting);
    }
}