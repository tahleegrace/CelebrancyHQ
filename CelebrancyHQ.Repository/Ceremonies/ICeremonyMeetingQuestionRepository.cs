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
        /// Finds the question for the specified meeting with the specified ceremony type meeting question.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="ceremonyTypeMeetingQuestionId">The ID of the ceremony type meeting question.</param>
        /// <returns>The question for the specified meeting with the specified ceremony type meeting question.returns>
        Task<CeremonyMeetingQuestion?> FindByCeremonyTypeMeetingQuestionId(int meetingId, int ceremonyTypeMeetingQuestionId);

        /// <summary>
        /// Creates new questions for a ceremony meeting.
        /// </summary>
        /// <param name="questions">The questions.</param>
        /// <returns>The newly created questions.</returns>
        Task<List<CeremonyMeetingQuestion>> Create(List<CeremonyMeetingQuestion> questions);

        /// <summary>
        /// Updates the details of the specified question.
        /// </summary>
        /// <param name="question">The question.</param>
        Task Update(CeremonyMeetingQuestion question);
    }
}