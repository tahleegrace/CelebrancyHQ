namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a person has already been added as a participant of the specified type to a ceremony.
    /// </summary>
    public class PersonAlreadyCeremonyParticipantException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony.
        /// </summary>
        public int CeremonyId { get; }

        /// <summary>
        /// Gets the ceremony type participant code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Creates a new instance of PersonAlreadyCeremonyParticipantException.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="code">The ceremony type participant code.</param>
        public PersonAlreadyCeremonyParticipantException(int ceremonyId, string code)
            : base()
        {
            this.CeremonyId = ceremonyId;
            this.Code = code;
        }
    }
}