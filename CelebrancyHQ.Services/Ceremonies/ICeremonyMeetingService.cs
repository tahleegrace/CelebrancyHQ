using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functionality for managing ceremony meetings.
    /// </summary>
    public interface ICeremonyMeetingService
    {
        /// <summary>
        /// Gets the ceremony meeting with the specified ID.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The ceremony meeting with the specified ID.</returns>
        Task<CeremonyMeetingDTO> GetCeremonyMeeting(int meetingId, int currentUserId);

        /// <summary>
        /// Gets the meetings for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The meetings for the specified ceremony.</returns>
        Task<List<CeremonyMeetingDTO>> GetCeremonyMeetings(int ceremonyId, int currentUserId);

        /// <summary>
        /// Creates a new ceremony meeting.
        /// </summary>
        /// <param name="meeting">The meeting.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created ceremony meeting.</returns>
        Task<CeremonyMeetingDTO> Create(CreateCeremonyMeetingRequest meeting, int ceremonyId, int currentUserId);

        /// <summary>
        /// Updates the details of the specified ceremony meeting.
        /// </summary>
        /// <param name="meeting">The meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task Update(UpdateCeremonyMeetingRequest meeting, int currentUserId);

        /// <summary>
        /// Updates the specified ceremony meeting question.
        /// </summary>
        /// <param name="question">The question.</param>
        /// <param name="meetingId">The meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task UpdateQuestion(UpdateCeremonyMeetingQuestionRequest question, int meetingId, int currentUserId);
    }
}