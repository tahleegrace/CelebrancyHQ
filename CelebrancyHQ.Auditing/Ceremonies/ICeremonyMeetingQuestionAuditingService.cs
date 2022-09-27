using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Ceremonies
{
    /// <summary>
    /// A service that handles audit logs for ceremony meeting questions.
    /// </summary>
    public interface ICeremonyMeetingQuestionAuditingService : IChildAuditingService<CeremonyMeetingQuestion, Ceremony>
    {
    }
}