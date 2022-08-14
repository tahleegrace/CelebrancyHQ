namespace CelebrancyHQ.Auditing
{
    /// <summary>
    /// An event that occurs when a sub field of an entity is updated (e.g. a phone number or ceremony participant).
    /// </summary>
    public abstract class SubFieldUpdatedEvent<FieldType> : FieldUpdatedEvent<FieldType>
    {
        /// <summary>
        /// Gets the ID of the entity that was updated.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the event data.
        /// </summary>
        public override Dictionary<string, object> EventData
        {
            get
            {
                var eventData = base.EventData;
                eventData.Add("Id", this.Id);

                return eventData;
            }
        }

        /// <summary>
        /// Creates a new instance of SubFieldUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the entity that was updated.</param>
        /// <param name="oldValue">The old value of the field.</param>
        /// <param name="newValue">The new value of the field.</param>
        public SubFieldUpdatedEvent(int id, FieldType oldValue, FieldType newValue)
            : base(oldValue, newValue)
        {
            this.Id = id;
        }
    }
}