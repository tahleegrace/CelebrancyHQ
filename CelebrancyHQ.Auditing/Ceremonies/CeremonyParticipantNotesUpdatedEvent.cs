namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when the notes for a ceremony participant are updated.
    /// </summary>
    public class CeremonyParticipantNotesUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Notes";

        /// <summary>
        /// Creates a new instance of CeremonyParticipantNotesUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old first name.</param>
        /// <param name="newValue">The new first name.</param>
        public CeremonyParticipantNotesUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}