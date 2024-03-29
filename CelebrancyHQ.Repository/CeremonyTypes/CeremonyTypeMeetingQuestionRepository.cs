﻿using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.CeremonyTypes
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
            _context = context;
        }

        /// <summary>
        /// Gets the ceremony type meeting question with the specified ID.
        /// </summary>
        /// <param name="ceremonyTypeMeetingQuestionId">The ID of the ceremony type meeting question.</param>
        /// <returns>The ceremony type meeting question with the specified ID.</returns>
        public async Task<CeremonyTypeMeetingQuestion?> FindById(int ceremonyTypeMeetingQuestionId)
        {
            return await _context.CeremonyTypeMeetingQuestions.Include(ctmq => ctmq.QuestionType)
                                                                   .Where(ctmq => ctmq.Id == ceremonyTypeMeetingQuestionId && !ctmq.Deleted)
                                                                   .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the questions for the specified ceremony type meeting.
        /// </summary>
        /// <param name="ceremonyTypeMeetingId">The ID of the ceremony type meeting.</param>
        /// <returns>The questions for the specified ceremony type meeting.</returns>
        public async Task<List<CeremonyTypeMeetingQuestion>> FindByCeremonyTypeMeetingId(int ceremonyTypeMeetingId)
        {
            return await _context.CeremonyTypeMeetingQuestions.Include(ctmq => ctmq.QuestionType)
                                                                   .Where(ctmq => ctmq.CeremonyTypeMeetingId == ceremonyTypeMeetingId && !ctmq.Deleted)
                                                                   .ToListAsync();
        }
    }
}