using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// A service that handles audit logs for ceremony files.
    /// </summary>
    public interface ICeremonyFileAuditingService : IChildAuditingService<CeremonyFile, Ceremony>
    {
    }
}