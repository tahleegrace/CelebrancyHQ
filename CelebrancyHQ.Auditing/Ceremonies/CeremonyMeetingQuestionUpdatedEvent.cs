namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when an question in a ceremony meeting is updated.
    /// </summary>
    public class CeremonyMeetingQuestionUpdatedEvent : SubFieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Meetings";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "Questions";

        /// <summary>
        /// Gets the ID of the ceremony type meeting question.
        /// </summary>
        public int CeremonyTypeMeetingQuestionId { get; }

        /// <summary>
        /// Gets the event data.
        /// </summary>
        public override Dictionary<string, object> EventData
        {
            get
            {
                var eventData = base.EventData;
                eventData.Add("CeremonyTypeMeetingQuestionId", this.CeremonyTypeMeetingQuestionId);

                return eventData;
            }
        }

        /// <summary>
        /// Creates a new instance of CeremonyMeetingQuestionUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the ceremony meeting.</param>
        /// <param name="oldValue">The old answer.</param>
        /// <param name="newValue">The new answer.</param>
        public CeremonyMeetingQuestionUpdatedEvent(int id, string? oldValue, string? newValue, int ceremonyTypeMeetingQuestionId)
            : base(id, oldValue, newValue)
        {
            this.CeremonyTypeMeetingQuestionId = ceremonyTypeMeetingQuestionId;
        }
    }
}