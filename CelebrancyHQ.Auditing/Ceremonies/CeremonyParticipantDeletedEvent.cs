using Newtonsoft.Json;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a ceremony participant is deleted.
    /// </summary>
    public class CeremonyParticipantDeletedEvent : EntityDeletedEvent<Person>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Participants";

        /// <summary>
        /// Gets the ID of the participant.
        /// </summary>
        [JsonIgnore]
        public int Id { get; }

        /// <summary>
        /// Gets the code of the participant.
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
        /// Creates a new instance of CeremonyParticipantDeletedEvent.
        /// </summary>
        /// <param name="id">The ID of the participant.</param>
        /// <param name="code">The code of the participant.</param>
        /// <param name="entityName">The name of the participant.</param>
        /// <param name="value">The participant.</param>
        public CeremonyParticipantDeletedEvent(int id, string code, string? entityName, Person value)
            : base(entityName, value)
        {
            this.Id = id;
            this.Code = code;
        }
    }
}