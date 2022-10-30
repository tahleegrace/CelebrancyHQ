namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony meeting question is not found.
    /// </summary>
    public class CeremonyMeetingQuestionNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony meeting question.
        /// </summary>
        public int CeremonyMeetingQuestionId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyMeetingQuestionNotFoundException.
        /// </summary>
        /// <param name="ceremonyMeetingQuestionId">The ID of the ceremony meeting question.</param>
        public CeremonyMeetingQuestionNotFoundException(int ceremonyMeetingQuestionId)
            : base()
        {
            this.CeremonyMeetingQuestionId = ceremonyMeetingQuestionId;
        }
    }
}