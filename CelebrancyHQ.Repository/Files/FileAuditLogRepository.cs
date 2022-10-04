using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Repository.Files
{
    /// <summary>
    /// The file audit logs repository.
    /// </summary>
    public class FileAuditLogRepository : IFileAuditLogRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of FileAuditLogRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public FileAuditLogRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a new file audit log.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        public async Task CreateAuditLog(FileAuditLog auditLog)
        {
            this._context.FileAuditLogs.Add(auditLog);
            await this._context.SaveChangesAsync();
        }
    }
}