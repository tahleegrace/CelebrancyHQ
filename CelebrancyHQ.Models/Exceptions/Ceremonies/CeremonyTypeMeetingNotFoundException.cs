namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony type meeting is not found.
    /// </summary>
    public class CeremonyTypeMeetingNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony type meeting.
        /// </summary>
        public int CeremonyTypeMeetingId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeMeetingNotFoundException.
        /// </summary>
        /// <param name="ceremonyTypeMeetingId">The ID of the ceremony type meeting.</param>
        public CeremonyTypeMeetingNotFoundException(int ceremonyTypeMeetingId)
            : base()
        {
            this.CeremonyTypeMeetingId = ceremonyTypeMeetingId;
        }
    }
}