using Newtonsoft.Json;

using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Auditing
{
    /// <summary>
    /// An event that occurs when an entity is deleted
    /// </summary>
    /// <typeparam name="FieldType"></typeparam>
    public abstract class EntityDeletedEvent<FieldType> : AuditEvent
    {
        /// <summary>
        /// Gets the event name.
        /// </summary>
        public override string EventName { get; } = EventNames.Delete.ToString();

        /// <summary>
        /// Gets the name of the entity that was deleted.
        /// </summary>
        [JsonIgnore]
        public string? EntityName { get; }

        /// <summary>
        /// Gets the value of the field.
        /// </summary>
        [JsonIgnore]
        public FieldType Value { get; }

        public override Dictionary<string, object> EventData
        {
            get
            {
                var result = new Dictionary<string, object>()
                {
                    { "Value", this.Value }
                };

                if (this.EntityName != null)
                {
                    result.Add("EntityName", this.EntityName);
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a new instance of EntityDeletedEvent.
        /// </summary>
        /// <param name="entityName">The name of the entity that was deleted.</param>
        /// <param name="value">The value of the field.</param>
        public EntityDeletedEvent(string? entityName, FieldType value)
        {
            this.EntityName = entityName;
            this.Value = value;
        }
    }
}