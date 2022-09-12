namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when the name of a ceremony meeting is updated.
    /// </summary>
    public class CeremonyMeetingNameUpdatedEvent : SubFieldUpdatedEvent<string>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Meetings";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "Name";

        /// <summary>
        /// Creates a new instance of CeremonyMeetingNameUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the ceremony meeting.</param>
        /// <param name="oldValue">The old name.</param>
        /// <param name="newValue">The new name.</param>
        public CeremonyMeetingNameUpdatedEvent(int id, string oldValue, string newValue)
            : base(id, oldValue, newValue)
        {
        }
    }
}