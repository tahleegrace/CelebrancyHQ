using Newtonsoft.Json;

using CelebrancyHQ.Auditing.Addresses;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;
using CelebrancyHQ.Repository.Organisations;

namespace CelebrancyHQ.Auditing.Organisations
{
    /// <summary>
    /// The organisation address auditing service.
    /// </summary>
    public class OrganisationAddressAuditingService : AddressAuditingService, IOrganisationAddressAuditingService
    {
        private readonly IOrganisationAuditLogRepository _organisationAuditLogRepository;

        /// <summary>
        /// Creates a new instance of OrganisationAddressAuditingService.
        /// </summary>
        /// <param name="organisationAuditLogRepository">The organisation audit logs repository.</param>
        public OrganisationAddressAuditingService(IOrganisationAuditLogRepository organisationAuditLogRepository)
        {
            this._organisationAuditLogRepository = organisationAuditLogRepository;
        }

        /// <summary>
        /// Saves a list of audit events.
        /// </summary>
        /// <param name="entity">The entity that was changed.</param>
        /// <param name="parentEntity">The parent entity.</param>
        /// <param name="personId">The ID of the person who made the changes.</param>
        /// <param name="auditEvents">The audit events to save.</param>
        public async Task SaveAuditEvents(Address entity, Organisation parentEntity, int personId, List<AuditEvent> auditEvents)
        {
            if (auditEvents == null || auditEvents.Count == 0)
            {
                return;
            }

            OrganisationAuditLog auditLog = new OrganisationAuditLog()
            {
                OrganisationId = parentEntity.Id,
                PersonId = personId,
                Event = JsonConvert.SerializeObject(auditEvents),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await this._organisationAuditLogRepository.CreateAuditLog(auditLog);
        }
    }
}