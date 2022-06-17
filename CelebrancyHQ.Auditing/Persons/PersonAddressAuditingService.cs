using Newtonsoft.Json;

using CelebrancyHQ.Auditing.Addresses;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;
using CelebrancyHQ.Repository.Persons;

namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// The person address auditing service.
    /// </summary>
    public class PersonAddressAuditingService : AddressAuditingService, IPersonAddressAuditingService
    {
        private readonly IPersonAuditLogRepository _personAuditLogRepository;

        /// <summary>
        /// Creates a new instance of PersonAddressAuditingService.
        /// </summary>
        /// <param name="personAuditLogRepository">The person audit logs repository.</param>
        public PersonAddressAuditingService(IPersonAuditLogRepository personAuditLogRepository)
        {
            this._personAuditLogRepository = personAuditLogRepository;
        }

        /// <summary>
        /// Saves a list of audit events.
        /// </summary>
        /// <param name="entity">The entity that was changed.</param>
        /// <param name="parentEntity">The parent entity.</param>
        /// <param name="personId">The ID of the person who made the changes.</param>
        /// <param name="auditEvents">The audit events to save.</param>
        public async Task SaveAuditEvents(Address entity, Person parentEntity, int personId, List<AuditEvent> auditEvents)
        {
            if (auditEvents == null || auditEvents.Count == 0)
            {
                return;
            }

            PersonAuditLog auditLog = new PersonAuditLog()
            {
                PersonId = parentEntity.Id,
                UpdatedById = personId,
                Event = JsonConvert.SerializeObject(auditEvents),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await this._personAuditLogRepository.CreateAuditLog(auditLog);
        }
    }
}