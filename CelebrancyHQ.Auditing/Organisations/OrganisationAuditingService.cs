using Newtonsoft.Json;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;
using CelebrancyHQ.Repository.Organisations;

namespace CelebrancyHQ.Auditing.Organisations
{
    /// <summary>
    /// The organisations auditing service.
    /// </summary>
    public class OrganisationAuditingService : IOrganisationAuditingService
    {
        private readonly IOrganisationAuditLogRepository _organisationAuditLogRepository;

        /// <summary>
        /// Creates a new instance of OrganisationAuditingService.
        /// </summary>
        /// <param name="organisationAuditLogRepository">The organisation audit logs repository.</param>
        public OrganisationAuditingService(IOrganisationAuditLogRepository organisationAuditLogRepository)
        {
            this._organisationAuditLogRepository = organisationAuditLogRepository;
        }

        /// <summary>
        /// Generates audit logs for the changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.
        /// </summary>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>A list of audit logs for changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.</returns>
        public List<AuditEvent> GenerateAuditEvents(Organisation? oldEntity, Organisation? newEntity)
        {
            List<AuditEvent> auditEvents = new List<AuditEvent>();

            if (oldEntity == null && newEntity != null)
            {
                auditEvents.Add(new OrganisationCreatedEvent(newEntity));
            }
            else if (oldEntity != null && newEntity == null)
            {
                auditEvents.Add(new OrganisationDeletedEvent(oldEntity));
            }

            return auditEvents;
        }

        /// <summary>
        /// Saves a list of audit events.
        /// </summary>
        /// <param name="entity">The entity that was changed.</param>
        /// <param name="personId">The ID of the person who made the changes.</param>
        /// <param name="auditEvents">The audit events to save.</param>
        public async Task SaveAuditEvents(Organisation entity, int personId, List<AuditEvent> auditEvents)
        {
            if (auditEvents == null || auditEvents.Count == 0)
            {
                return;
            }

            OrganisationAuditLog auditLog = new OrganisationAuditLog()
            {
                OrganisationId = entity.Id,
                PersonId = personId,
                Event = JsonConvert.SerializeObject(auditEvents),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await this._organisationAuditLogRepository.CreateAuditLog(auditLog);
        }
    }
}