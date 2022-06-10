namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when the name of a ceremony is updated.
    /// </summary>
    public class CeremonyNameUpdatedEvent : FieldUpdatedEvent
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Name";

        /// <summary>
        /// Creates a new instance of CeremonyNameUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old name of the ceremony.</param>
        /// <param name="newValue">The new name of the ceremony.</param>
        public CeremonyNameUpdatedEvent(string oldValue, string newValue)
            : base(oldValue, newValue)
        {
        }
    }
}