using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// A service that handles audit logs for ceremony service providers.
    /// </summary>
    public interface ICeremonyServiceProviderAuditingService : IChildAuditingService<CeremonyServiceProvider, Ceremony>
    {
    }
}