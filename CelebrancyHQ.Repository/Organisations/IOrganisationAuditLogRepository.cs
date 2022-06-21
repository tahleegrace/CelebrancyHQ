using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Repository.Organisations
{
    /// <summary>
    /// An organisation audit log repository.
    /// </summary>
    public interface IOrganisationAuditLogRepository
    {
        /// <summary>
        /// Creates a new organisation audit log.
        /// </summary>
        /// <param name="auditLog">The audit log.</param>
        Task CreateAuditLog(OrganisationAuditLog auditLog);
    }
}