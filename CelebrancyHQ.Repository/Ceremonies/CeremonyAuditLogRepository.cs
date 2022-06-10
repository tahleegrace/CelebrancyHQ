using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony audit log repository.
    /// </summary>
    public class CeremonyAuditLogRepository : ICeremonyAuditLogRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyAuditLogRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyAuditLogRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a new ceremony audit log.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        public async Task CreateAuditLog(CeremonyAuditLog auditLog)
        {
            this._context.CeremonyAuditLogs.Add(auditLog);
            await this._context.SaveChangesAsync();
        }
    }
}