namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a user is not a participant in a ceremony.
    /// </summary>
    public class UserNotCeremonyParticipantException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony.
        /// </summary>
        public int CeremonyId { get; }

        /// <summary>
        /// Creates a new instance of UserNotCeremonyParticipantException.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        public UserNotCeremonyParticipantException(int ceremonyId)
            : base()
        {
            this.CeremonyId = ceremonyId;
        }
    }
}