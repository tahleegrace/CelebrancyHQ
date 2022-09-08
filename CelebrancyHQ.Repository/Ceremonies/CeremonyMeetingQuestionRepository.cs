using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony meeting questions repository.
    /// </summary>
    public class CeremonyMeetingQuestionRepository : ICeremonyMeetingQuestionRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyMeetingQuestionRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyMeetingQuestionRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the questions for the specified ceremony meeting.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <returns>The questions for the specified ceremony meeting.</returns>
        public async Task<List<CeremonyMeetingQuestion>> GetQuestionsForMeeting(int meetingId)
        {
            return await this._context.CeremonyMeetingQuestions.Where(cmq => cmq.CeremonyMeetingId == meetingId && !cmq.Deleted).ToListAsync();
        }

        /// <summary>
        /// Creates new questions for a ceremony meeting.
        /// </summary>
        /// <param name="questions">The questions.</param>
        /// <returns>The newly created questions.</returns>
        public async Task<List<CeremonyMeetingQuestion>> Create(List<CeremonyMeetingQuestion> questions)
        {
            if (questions == null || questions.Count == 0)
            {
                return new List<CeremonyMeetingQuestion>();
            }

            foreach (var question in questions)
            {
                question.Created = DateTime.UtcNow;
                question.Updated = DateTime.UtcNow;

                this._context.CeremonyMeetingQuestions.Add(question);
            }

            await this._context.SaveChangesAsync();

            return questions;
        }
    }
}