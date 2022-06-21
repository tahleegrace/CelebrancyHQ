using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Repository.Organisations
{
    /// <summary>
    /// The organisation audit log repository.
    /// </summary>
    public class OrganisationAuditLogRepository : IOrganisationAuditLogRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of OrganisationAuditLogRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public OrganisationAuditLogRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a new organisation audit log.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        public async Task CreateAuditLog(OrganisationAuditLog auditLog)
        {
            this._context.OrganisationAuditLogs.Add(auditLog);
            await this._context.SaveChangesAsync();
        }
    }
}