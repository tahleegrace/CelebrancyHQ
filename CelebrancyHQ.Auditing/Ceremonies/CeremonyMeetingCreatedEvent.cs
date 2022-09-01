using Newtonsoft.Json;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a ceremony meeting is created.
    /// </summary>
    public class CeremonyMeetingCreatedEvent : EntityCreatedEvent<CeremonyMeeting>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Meetings";

        /// <summary>
        /// Gets the ID of the meeting.
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
                eventData.Add("CeremonyTypeMeetingId", this.Value.CeremonyTypeMeetingId);
                eventData.Add("Description", this.Value.Description);
                eventData.Add("Date", this.Value.Date);

                return eventData;
            }
        }

        /// <summary>
        /// Creates a new instance of CeremonyMeetingCreatedEvent.
        /// </summary>
        /// <param name="id">The ID of the meeting.</param>
        /// <param name="entityName">The name of the new meeting.</param>
        /// <param name="value">The new meeting.</param>
        public CeremonyMeetingCreatedEvent(int id, string? entityName, CeremonyMeeting value)
            : base(entityName, value)
        {
            this.Id = id;
        }
    }
}