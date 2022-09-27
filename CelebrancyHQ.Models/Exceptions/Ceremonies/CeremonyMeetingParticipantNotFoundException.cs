namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony meeting participant is not found.
    /// </summary>
    public class CeremonyMeetingParticipantNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the meeting.
        /// </summary>
        public int MeetingId { get; }

        /// <summary>
        /// Gets the ID of the person.
        /// </summary>
        public int PersonId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyMeetingParticipantNotFoundException.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="personId">The ID of the person.</param>
        public CeremonyMeetingParticipantNotFoundException(int meetingId, int personId)
            : base()
        {
            this.MeetingId = meetingId;
            this.PersonId = personId;
        }
    }
}