using Newtonsoft.Json;

using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Auditing
{
    /// <summary>
    /// An event that occurs when a new entity is created.
    /// </summary>
    public abstract class EntityCreatedEvent<FieldType> : AuditEvent
    {
        /// <summary>
        /// Gets the event name.
        /// </summary>
        public override string EventName { get; } = EventNames.Create.ToString();

        /// <summary>
        /// Gets the name of the new entity.
        /// </summary>
        [JsonIgnore]
        public string EntityName { get; }

        /// <summary>
        /// Gets the value of the field.
        /// </summary>
        [JsonIgnore]
        public FieldType Value { get; }

        public override Dictionary<string, object> EventData => new Dictionary<string, object>()
        {
            { "EntityName", this.EntityName },
            { "Value", this.Value }
        };

        /// <summary>
        /// Creates a new instance of EntityCreatedEvent.
        /// </summary>
        /// <param name="entityName">The name of the new entity.</param>
        /// <param name="value">The value of the field.</param>
        public EntityCreatedEvent(string entityName, FieldType value)
        {
            this.EntityName = entityName;
            this.Value = value;
        }
    }
}