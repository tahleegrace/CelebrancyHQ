namespace CelebrancyHQ.Auditing.Files
{
    /// <summary>
    /// An event that occurs when a file is created.
    /// </summary>
    public class FileCreatedEvent : EntityCreatedEvent<Entities.File>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Files";

        /// <summary>
        /// Creates a new instance of FileCreatedEvent.
        /// </summary>
        /// <param name="value">The new file.</param>
        public FileCreatedEvent(Entities.File value)
            : base(null, value)
        {
        }
    }
}