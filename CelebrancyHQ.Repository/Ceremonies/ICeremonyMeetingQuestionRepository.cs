using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony meeting questions repository.
    /// </summary>
    public interface ICeremonyMeetingQuestionRepository
    {
        /// <summary>
        /// Creates new questions for a ceremony meeting.
        /// </summary>
        /// <param name="questions">The questions.</param>
        /// <returns>The newly created questions.</returns>
        Task<List<CeremonyMeetingQuestion>> Create(List<CeremonyMeetingQuestion> questions);
    }
}