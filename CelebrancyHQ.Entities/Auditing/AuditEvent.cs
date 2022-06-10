namespace CelebrancyHQ.Entities.Auditing
{
    /// <summary>
    /// An audit log for an entity.
    /// </summary>
    public abstract class AuditEvent
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public abstract string FieldName { get; }

        /// <summary>
        /// Gets the event name.
        /// </summary>
        public abstract string EventName { get; }

        /// <summary>
        /// Gets the event data.
        /// </summary>
        public abstract Dictionary<string, object> EventData { get; }
    }
}