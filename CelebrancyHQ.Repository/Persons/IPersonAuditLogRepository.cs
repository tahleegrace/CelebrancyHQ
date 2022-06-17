using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Repository.Persons
{
    /// <summary>
    /// A person audit log repository.
    /// </summary>
    public interface IPersonAuditLogRepository
    {
        /// <summary>
        /// Creates a new person audit log.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        Task CreateAuditLog(PersonAuditLog auditLog);
    }
}