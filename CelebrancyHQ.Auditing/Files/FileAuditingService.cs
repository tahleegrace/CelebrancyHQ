using Newtonsoft.Json;

using CelebrancyHQ.Entities.Auditing;
using CelebrancyHQ.Repository.Files;

namespace CelebrancyHQ.Auditing.Files
{
    /// <summary>
    /// The files auditing service.
    /// </summary>
    public class FileAuditingService : IFileAuditingService
    {
        private readonly IFileAuditLogRepository _fileAuditLogRepository;

        /// <summary>
        /// Creates a new instance of FileAuditingService.
        /// </summary>
        /// <param name="fileAuditLogRepository">The file audit logs repository.</param>
        public FileAuditingService(IFileAuditLogRepository fileAuditLogRepository)
        {
            this._fileAuditLogRepository = fileAuditLogRepository;
        }

        /// <summary>
        /// Generates audit logs for the changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.
        /// </summary>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>A list of audit logs for changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.</returns>
        public List<AuditEvent> GenerateAuditEvents(Entities.File? oldEntity, Entities.File? newEntity)
        {
            List<AuditEvent> auditEvents = new List<AuditEvent>();

            if (oldEntity == null && newEntity != null)
            {
                auditEvents.Add(new FileCreatedEvent(newEntity));
            }

            return auditEvents;
        }

        /// <summary>
        /// Saves a list of audit events.
        /// </summary>
        /// <param name="entity">The entity that was changed.</param>
        /// <param name="personId">The ID of the person who made the changes.</param>
        /// <param name="auditEvents">The audit events to save.</param>
        public async Task SaveAuditEvents(Entities.File entity, int personId, List<AuditEvent> auditEvents)
        {
            if (auditEvents == null || auditEvents.Count == 0)
            {
                return;
            }

            FileAuditLog auditLog = new FileAuditLog()
            {
                FileId = entity.Id,
                PersonId = personId,
                Event = JsonConvert.SerializeObject(auditEvents),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await this._fileAuditLogRepository.CreateAuditLog(auditLog);
        }
    }
}