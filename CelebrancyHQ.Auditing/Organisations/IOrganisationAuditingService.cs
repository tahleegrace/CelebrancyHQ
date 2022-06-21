using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Organisations
{
    /// <summary>
    /// A service that handles audit logs for an organisation.
    /// </summary>
    public interface IOrganisationAuditingService : IAuditingService<Organisation>
    {
    }
}