using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// A service that handles audit logs for person phone numbers.
    /// </summary>
    public interface IPersonPhoneNumberAuditingService : IChildAuditingService<PersonPhoneNumber, Person>
    {
    }
}