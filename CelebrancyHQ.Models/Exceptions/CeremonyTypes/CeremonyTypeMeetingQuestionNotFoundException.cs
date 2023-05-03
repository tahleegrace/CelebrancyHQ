namespace CelebrancyHQ.Models.Exceptions.CeremonyTypes
{
    /// <summary>
    /// An exception that occurs when a ceremony type meeting question is not found.
    /// </summary>
    public class CeremonyTypeMeetingQuestionNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony type meeting question.
        /// </summary>
        public int CeremonyTypeMeetingQuestionId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeMeetingQuestionNotFoundException.
        /// </summary>
        /// <param name="ceremonyTypeMeetingQuestionId">The ID of the ceremony type meeting question.</param>
        public CeremonyTypeMeetingQuestionNotFoundException(int ceremonyTypeMeetingQuestionId)
            : base()
        {
            CeremonyTypeMeetingQuestionId = ceremonyTypeMeetingQuestionId;
        }
    }
}