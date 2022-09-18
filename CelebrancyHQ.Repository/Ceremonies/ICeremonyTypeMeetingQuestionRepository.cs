using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony type meeting question repository.
    /// </summary>
    public interface ICeremonyTypeMeetingQuestionRepository
    {
        /// <summary>
        /// Gets the ceremony type meeting question with the specified ID.
        /// </summary>
        /// <param name="ceremonyTypeMeetingQuestionId">The ID of the ceremony type meeting question.</param>
        /// <returns>The ceremony type meeting question with the specified ID.</returns>
        Task<CeremonyTypeMeetingQuestion?> FindById(int ceremonyTypeMeetingQuestionId);

        /// <summary>
        /// Gets the questions for the specified ceremony type meeting.
        /// </summary>
        /// <param name="ceremonyTypeMeetingId">The ID of the ceremony type meeting.</param>
        /// <returns>The questions for the specified ceremony type meeting.</returns>
        Task<List<CeremonyTypeMeetingQuestion>> FindByCeremonyTypeMeetingId(int ceremonyTypeMeetingId);
    }
}