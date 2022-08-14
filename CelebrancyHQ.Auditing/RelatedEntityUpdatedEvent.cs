using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Auditing
{
    /// <summary>
    /// An event that occurs when an entity that is related to another field is updated.
    /// </summary>
    public abstract class RelatedEntityUpdatedEvent : AuditEvent
    {
        /// <summary>
        /// Gets the event name.
        /// </summary>
        public override string EventName { get; } = EventNames.Update.ToString();

        /// <summary>
        /// Gets the type of the related entity that was updated.
        /// </summary>
        public abstract string RelatedEntityType { get; }

        /// <summary>
        /// Gets the ID of the related entity that was updated.
        /// </summary>
        public int RelatedEntityId { get; }

        public override Dictionary<string, object> EventData => new Dictionary<string, object>();

        /// <summary>
        /// Creates a new instance of RelatedEntityUpdatedEvent.
        /// </summary>
        /// <param name="relatedEntityId">The ID of the related entity that was updated.</param>
        public RelatedEntityUpdatedEvent(int relatedEntityId)
        {
            this.RelatedEntityId = relatedEntityId;
        }
    }
}