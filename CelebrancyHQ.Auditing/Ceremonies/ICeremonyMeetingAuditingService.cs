using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// A service that handles audit logs for ceremony meetings.
    /// </summary>
    public interface ICeremonyMeetingAuditingService : IChildAuditingService<CeremonyMeeting, Ceremony>
    {
    }
}