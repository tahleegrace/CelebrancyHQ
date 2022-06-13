using Newtonsoft.Json;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a ceremony date is created.
    /// </summary>
    public class CeremonyDateCreatedEvent : EntityCreatedEvent<DateTime>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Dates";

        /// <summary>
        /// Gets the ID of the date.
        /// </summary>
        [JsonIgnore]
        public int Id { get; }

        /// <summary>
        /// Gets or sets the code of the date.
        /// </summary>
        [JsonIgnore]
        public string Code { get; }

        /// <summary>
        /// Gets the event data.
        /// </summary>
        public override Dictionary<string, object> EventData
        {
            get
            {
                var eventData = base.EventData;
                eventData.Add("Id", this.Id);
                eventData.Add("Code", this.Code);

                return eventData;
            }
        }

        /// <summary>
        /// Creates a new instance of CeremonyDateCreatedEvent.
        /// </summary>
        /// <param name="id">The ID of the date.</param>
        /// <param name="code">The code of the date.</param>
        /// <param name="entityName">The name of the new date.</param>
        /// <param name="value">The new date.</param>
        public CeremonyDateCreatedEvent(int id, string code, string entityName, DateTime value)
            : base(entityName, value)
        {
            this.Id = id;
            this.Code = code;
        }
    }
}