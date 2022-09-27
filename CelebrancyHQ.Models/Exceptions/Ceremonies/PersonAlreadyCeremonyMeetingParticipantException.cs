namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a person has already been added as a participant to a ceremony meeting.
    /// </summary>
    public class PersonAlreadyCeremonyMeetingParticipantException : Exception
    {
        /// <summary>
        /// Gets the ID of the meetingId
        /// </summary>
        public int MeetingId { get; }

        /// <summary>
        /// Gets the person ID.
        /// </summary>
        public int PersonId { get; }

        /// <summary>
        /// Creates a new instance of PersonAlreadyCeremonyMeetingParticipantException.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="personId">The ID of the person.</param>
        public PersonAlreadyCeremonyMeetingParticipantException(int meetingId, int personId)
            : base()
        {
            this.MeetingId = meetingId;
            this.PersonId = personId;
        }
    }
}