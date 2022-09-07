using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// A service that handles audit logs for ceremony meeting participants.
    /// </summary>
    public interface ICeremonyMeetingParticipantAuditingService : IChildAuditingService<CeremonyMeetingParticipant, Ceremony>
    {
    }
}