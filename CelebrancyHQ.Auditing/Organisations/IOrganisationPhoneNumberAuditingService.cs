using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Organisations
{
    /// <summary>
    /// A service that handles audit logs for organisation phone numbers.
    /// </summary>
    public interface IOrganisationPhoneNumberAuditingService : IChildAuditingService<OrganisationPhoneNumber, Organisation>
    {
    }
}