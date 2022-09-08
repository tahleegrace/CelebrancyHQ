using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony meeting questions repository.
    /// </summary>
    public interface ICeremonyMeetingQuestionRepository
    {
        /// <summary>
        /// Gets the questions for the specified ceremony meeting.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <returns>The questions for the specified ceremony meeting.</returns>
        Task<List<CeremonyMeetingQuestion>> GetQuestionsForMeeting(int meetingId);

        /// <summary>
        /// Creates new questions for a ceremony meeting.
        /// </summary>
        /// <param name="questions">The questions.</param>
        /// <returns>The newly created questions.</returns>
        Task<List<CeremonyMeetingQuestion>> Create(List<CeremonyMeetingQuestion> questions);
    }
}