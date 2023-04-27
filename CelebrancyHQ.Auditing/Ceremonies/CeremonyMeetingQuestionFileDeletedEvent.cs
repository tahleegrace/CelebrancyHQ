namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a ceremony meeting question file is deleted.
    /// </summary>
    public class CeremonyMeetingQuestionFileDeletedEvent : SubFieldDeletedEvent<int>
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
        /// Creates a new instance of CeremonyMeetingQuestionFileDeletedEvent.
        /// </summary>
        /// <param name="id">The ID of the ceremony meeting question file.</param>
        /// <param name="parentId">The ID of the ceremony meeting question.</param>
        /// <param name="fileId">The ID of the ceremony file.</param>
        public CeremonyMeetingQuestionFileDeletedEvent(int id, int parentId, int fileId)
            : base(id, parentId, null, fileId)
        {

        }
    }
}