using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Repository.Files
{
    /// <summary>
    /// A file audit logs repository.
    /// </summary>
    public interface IFileAuditLogRepository
    {
        /// <summary>
        /// Creates a new file audit log.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        Task CreateAuditLog(FileAuditLog auditLog);
    }
}