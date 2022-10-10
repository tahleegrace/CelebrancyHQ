using Newtonsoft.Json;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a ceremony file is created.
    /// </summary>
    public class CeremonyFileCreatedEvent : EntityCreatedEvent<CeremonyFile>
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
                eventData.Add("Description", this.Value.Description);

                return eventData;
            }
        }

        /// <summary>
        /// Creates a new instance of CeremonyFileCreatedEvent.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <param name="entityName">The name of the new file.</param>
        /// <param name="value">The new file.</param>
        public CeremonyFileCreatedEvent(int id, string? entityName, CeremonyFile value)
            : base(entityName, value)
        {
            this.Id = id;
        }
    }
}