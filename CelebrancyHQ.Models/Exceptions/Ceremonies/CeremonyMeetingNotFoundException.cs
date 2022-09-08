namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony meeting is not found.
    /// </summary>
    public class CeremonyMeetingNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony meeting.
        /// </summary>
        public int CeremonyMeetingId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyMeetingNotFoundException.
        /// </summary>
        /// <param name="ceremonyMeetingId">The ID of the ceremony meeting.</param>
        public CeremonyMeetingNotFoundException(int ceremonyMeetingId)
            : base()
        {
            this.CeremonyMeetingId = ceremonyMeetingId;
        }
    }
}