namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when the notes for a ceremony participant are updated.
    /// </summary>
    public class CeremonyParticipantNotesUpdatedEvent : SubFieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Participants";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "Notes";

        /// <summary>
        /// Creates a new instance of CeremonyParticipantNotesUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the ceremony participant.</param>
        /// <param name="oldValue">The old first name.</param>
        /// <param name="newValue">The new first name.</param>
        public CeremonyParticipantNotesUpdatedEvent(int id, string? oldValue, string? newValue)
            : base(id, oldValue, newValue)
        {
        }
    }
}