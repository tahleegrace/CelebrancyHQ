using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// A service that handles audit logs for ceremony participants.
    /// </summary>
    public interface ICeremonyParticipantAuditingService : IChildAuditingService<CeremonyParticipant, Ceremony>
    {
    }
}