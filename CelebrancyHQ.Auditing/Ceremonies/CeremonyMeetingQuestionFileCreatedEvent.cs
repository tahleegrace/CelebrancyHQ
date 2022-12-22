namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a cereony meeting question file is added.
    /// </summary>
    public class CeremonyMeetingQuestionFileCreatedEvent : SubFieldCreatedEvent<int>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Questions";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "Files";

        /// <summary>
        /// Creates a new instance of CeremonyMeetingQuestionFileCreatedEvent.
        /// </summary>
        /// <param name="id">The ID of the ceremony meeting file.</param>
        /// <param name="parentId">The ID of the ceremony meeting question.</param>
        /// <param name="fileId">The ID of the ceremony file.</param>
        public CeremonyMeetingQuestionFileCreatedEvent(int id, int parentId, int fileId)
            : base(id, parentId, null, fileId)
        {
        }
    }
}