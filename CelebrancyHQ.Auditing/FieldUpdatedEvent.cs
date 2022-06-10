using CelebrancyHQ.Entities.Auditing;
using Newtonsoft.Json;

namespace CelebrancyHQ.Auditing
{
    /// <summary>
    /// An event that occurs when the value of a field is updated.
    /// </summary>
    public abstract class FieldUpdatedEvent : AuditEvent
    {
        /// <summary>
        /// Gets the event name.
        /// </summary>
        public override string EventName { get; } = EventNames.Update.ToString();

        /// <summary>
        /// Gets the old value of the field.
        /// </summary>
        [JsonIgnore]
        public string OldValue { get; }

        /// <summary>
        /// Gets the new value of the field.
        /// </summary>
        [JsonIgnore]
        public string NewValue { get; }

        public override Dictionary<string, object> EventData => new Dictionary<string, object>()
        {
            { "OldValue", this.OldValue },
            { "NewValue", this.NewValue }
        };

        /// <summary>
        /// Creates a new instance of FieldUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old value of the field.</param>
        /// <param name="newValue">The new value of the field.</param>
        public FieldUpdatedEvent(string oldValue, string newValue)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    }
}