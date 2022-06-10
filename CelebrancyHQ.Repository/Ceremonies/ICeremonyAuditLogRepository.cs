using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony audit log repository.
    /// </summary>
    public interface ICeremonyAuditLogRepository
    {
        /// <summary>
        /// Creates a new ceremony audit log.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        Task CreateAuditLog(CeremonyAuditLog auditLog);
    }
}