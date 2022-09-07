namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a participant is added to a ceremony meeting.
    /// </summary>
    public class CeremonyMeetingParticipantCreatedEvent : SubFieldCreatedEvent<int>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Meetings";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "Participants";

        /// <summary>
        /// Creates a new instance of CeremonyMeetingParticipantCreatedEvent.
        /// </summary>
        /// <param name="id">The ID of the ceremony meeting participant.</param>
        /// <param name="parentId">The ID of the ceremony meeting.</param>
        /// <param name="personId">The ID of the person who is the participant.</param>
        public CeremonyMeetingParticipantCreatedEvent(int id, int parentId, int personId)
            : base(id, parentId, null, personId)
        {
            
        }
    }
}