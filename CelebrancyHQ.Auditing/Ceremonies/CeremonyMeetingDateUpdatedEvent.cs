namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when the date of a ceremony meeting is updated.
    /// </summary>
    public class CeremonyMeetingDateUpdatedEvent : SubFieldUpdatedEvent<DateTime>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Meetings";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "Date";

        /// <summary>
        /// Creates a new instance of CeremonyMeetingDateUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the ceremony meeting.</param>
        /// <param name="oldValue">The old date.</param>
        /// <param name="newValue">The new date.</param>
        public CeremonyMeetingDateUpdatedEvent(int id, DateTime oldValue, DateTime newValue)
            : base(id, oldValue, newValue)
        {
        }
    }
}