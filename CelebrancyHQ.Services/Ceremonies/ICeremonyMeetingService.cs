using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functionality for managing ceremony meetings.
    /// </summary>
    public interface ICeremonyMeetingService
    {
        /// <summary>
        /// Creates a new ceremony meeting.
        /// </summary>
        /// <param name="meeting">The meeting.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created ceremony meeting.</returns>
        Task<CeremonyMeetingDTO> Create(CreateCeremonyMeetingRequest meeting, int ceremonyId, int currentUserId);
    }
}