using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// A service that handles audit logs for ceremony meeting question files.
    /// </summary>
    public interface ICeremonyMeetingQuestionFileAuditingService : IChildAuditingService<CeremonyMeetingQuestionFile, Ceremony>
    {
    }
}