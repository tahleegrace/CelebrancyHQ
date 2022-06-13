using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// A service that handles audit logs for ceremony dates.
    /// </summary>
    public interface ICeremonyDateAuditingService : IChildAuditingService<CeremonyDate, Ceremony>
    {
    }
}