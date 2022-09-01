using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony type meeting questions repository.
    /// </summary>
    public class CeremonyTypeMeetingQuestionRepository : ICeremonyTypeMeetingQuestionRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeMeetingQuestionRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyTypeMeetingQuestionRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the questions for the specified ceremony type meeting.
        /// </summary>
        /// <param name="ceremonyTypeMeetingId">The ID of the ceremony type meeting.</param>
        /// <returns>The questions for the specified ceremony type meeting.</returns>
        public async Task<List<CeremonyTypeMeetingQuestion>> FindByCeremonyTypeMeetingId(int ceremonyTypeMeetingId)
        {
            return await this._context.CeremonyTypeMeetingQuestions.Where(ctmq => ctmq.CeremonyTypeMeetingId == ceremonyTypeMeetingId && !ctmq.Deleted).ToListAsync();
        }
    }
}