namespace CelebrancyHQ.Auditing
{
    /// <summary>
    /// An event that occurs when a sub field of an entity is deleted (e.g. a ceremony meeting participant).
    /// </summary>
    public abstract class SubFieldDeletedEvent<FieldType> : EntityDeletedEvent<FieldType>
    {
        /// <summary>
        /// Gets the ID of the entity that was deleted.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the ID of the parent entity (e.g. a ceremony meeting).
        /// </summary>
        public int ParentId { get; }

        /// <summary>
        /// Gets the event data.
        /// </summary>
        public override Dictionary<string, object> EventData
        {
            get
            {
                var eventData = base.EventData;
                eventData.Add("Id", this.Id);
                eventData.Add("ParentId", this.ParentId);

                return eventData;
            }
        }

        /// <summary>
        /// Creates a new instance of SubFieldDeletedEvent.
        /// </summary>
        /// <param name="id">The ID of the deleted entity.</param>
        /// <param name="parentId">The ID of the parent entity.</param>
        /// <param name="entityName">The name of the deleted entity.</param>
        /// <param name="value">The value of the field.</param>
        public SubFieldDeletedEvent(int id, int parentId, string? entityName, FieldType value)
            : base(entityName, value)
        {
            this.Id = id;
            this.ParentId = parentId;
        }
    }
}