using Newtonsoft.Json;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a ceremony date is updated.
    /// </summary>
    public class CeremonyDateUpdatedEvent : FieldUpdatedEvent<DateTime?>
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
        /// Creates a new instance of CeremonyDateUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the date.</param>
        /// <param name="code">The code of the date.</param>
        /// <param name="oldValue">The old date.</param>
        /// <param name="newValue">The new date.</param>
        public CeremonyDateUpdatedEvent(int id, string code, DateTime? oldValue, DateTime? newValue)
            : base(oldValue, newValue)
        {
            this.Id = id;
            this.Code = code;
        }
    }
}