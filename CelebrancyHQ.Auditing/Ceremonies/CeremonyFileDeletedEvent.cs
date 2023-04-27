using Newtonsoft.Json;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a ceremony file is deleted.
    /// </summary>
    public class CeremonyFileDeletedEvent : EntityDeletedEvent<CeremonyFile>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Files";

        /// <summary>
        /// Gets the ID of the file.
        /// </summary>
        [JsonIgnore]
        public int Id { get; }

        /// <summary>
        /// Gets the event data.
        /// </summary>
        public override Dictionary<string, object> EventData
        {
            get
            {
                var eventData = new Dictionary<string, object>();
                eventData.Add("Id", this.Id);
                eventData.Add("FileId", this.Value.FileId);
                eventData.Add("CategoryId", this.Value.CategoryId);

                return eventData;
            }
        }

        /// <summary>
        /// Creates a new instance of CeremonyFileDeletedEvent.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <param name="entityName">The name of the file.</param>
        /// <param name="value">The file.</param>
        public CeremonyFileDeletedEvent(int id, string? entityName, CeremonyFile value)
            : base(entityName, value)
        {
            this.Id = id;
        }
    }
}