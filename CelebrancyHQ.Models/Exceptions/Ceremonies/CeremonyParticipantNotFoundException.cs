namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony participant is not found.
    /// </summary>
    public class CeremonyParticipantNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony participant.
        /// </summary>
        public int CeremonyParticipantId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyParticipantNotFoundException.
        /// </summary>
        /// <param name="ceremonyParticipantId">The ID of the ceremony participant.</param>
        public CeremonyParticipantNotFoundException(int ceremonyParticipantId)
            : base()
        {
            this.CeremonyParticipantId = ceremonyParticipantId;
        }
    }
}