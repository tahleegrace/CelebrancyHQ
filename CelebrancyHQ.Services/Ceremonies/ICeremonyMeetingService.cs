using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.Persons;

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
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task UpdateQuestion(UpdateCeremonyMeetingQuestionRequest question, int meetingId, int currentUserId);

        /// <summary>
        /// Creates a new ceremony meeting participant.
        /// </summary>
        /// <param name="personId">The ID of the person to be added as a participant.</param>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created participant.</returns>
        Task<PersonDTO> CreateParticipant(int personId, int meetingId, int currentUserId);

        /// <summary>
        /// Deletes a ceremony meeting participant.
        /// </summary>
        /// <param name="personId">The ID of the person to be removed as a participant.</param>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task DeleteParticipant(int personId, int meetingId, int currentUserId);
    }
}