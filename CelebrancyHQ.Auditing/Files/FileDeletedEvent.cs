using CelebrancyHQ.Entities;
using Newtonsoft.Json;

namespace CelebrancyHQ.Auditing.Files
{
    /// <summary>
    /// An event that occurs when a file is deleted.
    /// </summary>
    public class FileDeletedEvent : EntityDeletedEvent<Entities.File>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Dates";

        /// <summary>
        /// Creates a new instance of FileDeletedEvent.
        /// </summary>
        /// <param name="value">The file that was deleted.</param>
        public FileDeletedEvent(Entities.File value)
            : base(null, value)
        {
        }
    }
}