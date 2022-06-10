using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;
using CelebrancyHQ.Repository.Ceremonies;
using Newtonsoft.Json;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// The ceremony auditing service.
    /// </summary>
    public class CeremonyAuditingService : ICeremonyAuditingService
    {
        private readonly ICeremonyAuditLogRepository _ceremonyAuditLogRepository;

        /// <summary>
        /// Creates a new instance of CeremonyAuditingService.
        /// </summary>
        /// <param name="ceremonyAuditLogRepository">The ceremony audit logs repository.</param>
        public CeremonyAuditingService(ICeremonyAuditLogRepository ceremonyAuditLogRepository)
        {
            this._ceremonyAuditLogRepository = ceremonyAuditLogRepository;
        }

        /// <summary>
        /// Generates audit logs for the changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.
        /// </summary>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>A list of audit logs for changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.</returns>
        public List<AuditEvent> GenerateAuditEvents(Ceremony oldEntity, Ceremony newEntity)
        {
            // TODO: Handle creating new ceremonies here.
            if (newEntity == null)
            {
                throw new ArgumentNullException(nameof(newEntity));
            }

            List<AuditEvent> auditEvents = new List<AuditEvent>();

            if (oldEntity.Name != newEntity.Name)
            {
                auditEvents.Add(new CeremonyNameUpdatedEvent(oldEntity.Name, newEntity.Name));
            }

            return auditEvents;
        }

        /// <summary>
        /// Saves a list of audit events.
        /// </summary>
        /// <param name="entity">The entity that was changed.</param>
        /// <param name="personId">The ID of the user who made the changes.</param>
        /// <param name="auditEvents">The audit events to save.</param>
        public async Task SaveAuditEvents(Ceremony entity, int personId, List<AuditEvent> auditEvents)
        {
            if (auditEvents == null || auditEvents.Count == 0)
            {
                return;
            }

            CeremonyAuditLog auditLog = new CeremonyAuditLog()
            {
                CeremonyId = entity.Id,
                PersonId = personId,
                Event = JsonConvert.SerializeObject(auditEvents),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await this._ceremonyAuditLogRepository.CreateAuditLog(auditLog);
        }
    }
}