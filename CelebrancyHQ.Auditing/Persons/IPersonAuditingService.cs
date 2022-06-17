using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// A service that handles audit logs for a person.
    /// </summary>
    public interface IPersonAuditingService : IAuditingService<Person>
    {
    }
}