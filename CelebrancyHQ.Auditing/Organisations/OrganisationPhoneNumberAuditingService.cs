using Newtonsoft.Json;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;
using CelebrancyHQ.Repository.Organisations;

namespace CelebrancyHQ.Auditing.Organisations
{
    /// <summary>
    /// The organisation phone number auditing service.
    /// </summary>
    public class OrganisationPhoneNumberAuditingService : IOrganisationPhoneNumberAuditingService
    {
        private readonly IOrganisationAuditLogRepository _organisationAuditLogRepository;

        /// <summary>
        /// Creates a new instance of OrganisationPhoneNumberAuditingService.
        /// </summary>
        /// <param name="organisationAuditLogRepository">The organisation audit logs repository.</param>
        public OrganisationPhoneNumberAuditingService(IOrganisationAuditLogRepository organisationAuditLogRepository)
        {
            this._organisationAuditLogRepository = organisationAuditLogRepository;
        }

        /// <summary>
        /// Generates audit logs for the changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.
        /// </summary>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>A list of audit logs for changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.</returns>
        public List<AuditEvent> GenerateAuditEvents(OrganisationPhoneNumber? oldEntity, OrganisationPhoneNumber? newEntity)
        {
            List<AuditEvent> auditEvents = new List<AuditEvent>();

            if (oldEntity == null && newEntity != null)
            {
                auditEvents.Add(new OrganisationPhoneNumberCreatedEvent(newEntity));
            }

            return auditEvents;
        }

        /// <summary>
        /// Saves a list of audit events.
        /// </summary>
        /// <param name="entity">The entity that was changed.</param>
        /// <param name="parentEntity">The parent entity.</param>
        /// <param name="personId">The ID of the person who made the changes.</param>
        /// <param name="auditEvents">The audit events to save.</param>
        public async Task SaveAuditEvents(OrganisationPhoneNumber entity, Organisation parentEntity, int personId, List<AuditEvent> auditEvents)
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