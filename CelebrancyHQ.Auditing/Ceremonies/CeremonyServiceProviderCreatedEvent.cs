using Newtonsoft.Json;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// An event that occurs when a ceremony service provider is created.
    /// </summary>
    public class CeremonyServiceProviderCreatedEvent : EntityCreatedEvent<Organisation>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "ServiceProviders";

        /// <summary>
        /// Gets the ID of the service provider.
        /// </summary>
        [JsonIgnore]
        public int Id { get; }

        /// <summary>
        /// Gets the code of the service provider.
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
        /// Creates a new instance of CeremonyServiceProviderCreatedEvent.
        /// </summary>
        /// <param name="id">The ID of the service provider.</param>
        /// <param name="code">The code of the service provider.</param>
        /// <param name="entityName">The name of the new service provider.</param>
        /// <param name="value">The new service provider.</param>
        public CeremonyServiceProviderCreatedEvent(int id, string code, string? entityName, Organisation value)
            : base(entityName, value)
        {
            this.Id = id;
            this.Code = code;
        }
    }
}