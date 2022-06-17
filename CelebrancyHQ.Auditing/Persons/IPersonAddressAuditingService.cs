using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// A service that handles audit logs for person addresses.
    /// </summary>
    public interface IPersonAddressAuditingService : IChildAuditingService<Address, Person>
    {
    }
}