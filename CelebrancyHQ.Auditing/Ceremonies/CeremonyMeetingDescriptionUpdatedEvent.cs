namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when the description of a ceremony meeting is updated.
    /// </summary>
    public class CeremonyMeetingDescriptionUpdatedEvent : SubFieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Meetings";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "Description";

        /// <summary>
        /// Creates a new instance of CeremonyMeetingDescriptionUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the ceremony meeting.</param>
        /// <param name="oldValue">The old description.</param>
        /// <param name="newValue">The new description.</param>
        public CeremonyMeetingDescriptionUpdatedEvent(int id, string? oldValue, string? newValue)
            : base(id, oldValue, newValue)
        {
        }
    }
}