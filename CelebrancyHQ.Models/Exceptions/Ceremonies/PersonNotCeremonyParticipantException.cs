namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a person is not a participant in a ceremony.
    /// </summary>
    public class PersonNotCeremonyParticipantException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony.
        /// </summary>
        public int CeremonyId { get; }

        /// <summary>
        /// Creates a new instance of PersonNotCeremonyParticipantException.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        public PersonNotCeremonyParticipantException(int ceremonyId)
            : base()
        {
            this.CeremonyId = ceremonyId;
        }
    }
}