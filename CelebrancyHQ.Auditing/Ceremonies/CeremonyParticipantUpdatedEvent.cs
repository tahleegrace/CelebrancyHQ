namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a ceremony participant has been updated.
    /// </summary>
    public class CeremonyParticipantUpdatedEvent : RelatedEntityUpdatedEvent
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Participants";

        /// <summary>
        /// Gets the type of the related entity that was updated.
        /// </summary>
        public override string RelatedEntityType { get; } = "Persons";

        /// <summary>
        /// Creates a new instance of CeremonyParticipantUpdatedEvent.
        /// </summary>
        /// <param name="relatedEntityId">The ID of the related entity that was updated.</param>
        public CeremonyParticipantUpdatedEvent(int relatedEntityId)
            : base(relatedEntityId)
        {
        }
    }
}