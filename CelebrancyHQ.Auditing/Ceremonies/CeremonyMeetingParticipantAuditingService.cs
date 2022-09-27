using Newtonsoft.Json;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;
using CelebrancyHQ.Repository.Ceremonies;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// The ceremony meeting participant auditing service.
    /// </summary>
    public class CeremonyMeetingParticipantAuditingService : ICeremonyMeetingParticipantAuditingService
    {
        private readonly ICeremonyAuditLogRepository _ceremonyAuditLogRepository;

        /// <summary>
        /// Creates a new instance of CeremonyMeetingParticipantAuditingService.
        /// </summary>
        /// <param name="ceremonyAuditLogRepository">The ceremony audit logs repository.</param>
        public CeremonyMeetingParticipantAuditingService(ICeremonyAuditLogRepository ceremonyAuditLogRepository)
        {
            this._ceremonyAuditLogRepository = ceremonyAuditLogRepository;
        }

        /// <summary>
        /// Generates audit logs for the changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.
        /// </summary>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>A list of audit logs for changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.</returns>
        public List<AuditEvent> GenerateAuditEvents(CeremonyMeetingParticipant? oldEntity, CeremonyMeetingParticipant? newEntity)
        {
            List<AuditEvent> auditEvents = new List<AuditEvent>();

            if (oldEntity == null && newEntity != null)
            {
                auditEvents.Add(new CeremonyMeetingParticipantCreatedEvent(newEntity.Id, newEntity.CeremonyMeetingId, newEntity.PersonId));
            }
            else if (oldEntity != null && newEntity == null)
            {
                auditEvents.Add(new CeremonyMeetingParticipantDeletedEvent(oldEntity.Id, oldEntity.CeremonyMeetingId, oldEntity.PersonId));
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
        public async Task SaveAuditEvents(CeremonyMeetingParticipant entity, Ceremony parentEntity, int personId, List<AuditEvent> auditEvents)
        {
            if (auditEvents == null || auditEvents.Count == 0)
            {
                return;
            }

            CeremonyAuditLog auditLog = new CeremonyAuditLog()
            {
                CeremonyId = parentEntity.Id,
                PersonId = personId,
                Event = JsonConvert.SerializeObject(auditEvents),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await this._ceremonyAuditLogRepository.CreateAuditLog(auditLog);
        }
    }
}