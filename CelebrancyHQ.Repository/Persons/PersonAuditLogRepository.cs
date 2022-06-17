using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Repository.Persons
{
    /// <summary>
    /// The person audit log repository.
    /// </summary>
    public class PersonAuditLogRepository : IPersonAuditLogRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of PersonAuditLogRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PersonAuditLogRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a new person audit log.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        public async Task CreateAuditLog(PersonAuditLog auditLog)
        {
            this._context.PersonAuditLogs.Add(auditLog);
            await this._context.SaveChangesAsync();
        }
    }
}