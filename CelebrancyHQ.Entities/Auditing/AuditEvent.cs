namespace CelebrancyHQ.Entities.Auditing
{
    /// <summary>
    /// An audit log for an entity.
    /// </summary>
    public abstract class AuditEvent
    {
        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        public abstract string FieldName { get; set; }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        public abstract string EventName { get; set; }

        /// <summary>
        /// Gets or sets the event data.
        /// </summary>
        public abstract Dictionary<string, object> EventData { get; set; }
    }
}