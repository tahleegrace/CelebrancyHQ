using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony type meeting question repository.
    /// </summary>
    public interface ICeremonyTypeMeetingQuestionRepository
    {
        /// <summary>
        /// Gets the questions for the specified ceremony type meeting.
        /// </summary>
        /// <param name="ceremonyTypeMeetingId">The ID of the ceremony type meeting.</param>
        /// <returns>The questions for the specified ceremony type meeting.</returns>
        Task<List<CeremonyTypeMeetingQuestion>> FindByCeremonyTypeMeetingId(int ceremonyTypeMeetingId);
    }
}