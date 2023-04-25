namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when the description of a ceremony file is updated.
    /// </summary>
    public class CeremonyFileDescriptionUpdatedEvent : SubFieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Files";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "Description";

        /// <summary>
        /// Creates a new instance of CeremonyFileDescriptionUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the ceremony file.</param>
        /// <param name="oldValue">The old description.</param>
        /// <param name="newValue">The new description.</param>
        public CeremonyFileDescriptionUpdatedEvent(int id, string? oldValue, string? newValue)
            : base(id, oldValue, newValue)
        {
        }
    }
}