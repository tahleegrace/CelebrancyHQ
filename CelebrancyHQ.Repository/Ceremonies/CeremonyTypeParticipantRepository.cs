﻿using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony type participants repository.
    /// </summary>
    public class CeremonyTypeParticipantRepository : ICeremonyTypeParticipantRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeParticipantRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyTypeParticipantRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the IDs of the ceremony type participants with the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>The IDs of the ceremony type participants with the specified code.</returns>
        public async Task<List<int>> FindIdsByCode(string code)
        {
            var ids = await this._context.CeremonyTypeParticipants.Where(tp => tp.Code == code && !tp.Deleted)
                                                                  .Select(tp => tp.Id)
                                                                  .ToListAsync();

            return ids;
        }
    }
}