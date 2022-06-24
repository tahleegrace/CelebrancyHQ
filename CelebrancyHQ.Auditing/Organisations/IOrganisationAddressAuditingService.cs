using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Organisations
{
    /// <summary>
    /// A service that handles audit logs for organisation addresses.
    /// </summary>
    public interface IOrganisationAddressAuditingService : IChildAuditingService<Address, Organisation>
    {
    }
}