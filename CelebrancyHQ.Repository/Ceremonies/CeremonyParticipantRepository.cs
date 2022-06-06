using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony participant repository.
    /// </summary>
    public class CeremonyParticipantRepository : ICeremonyParticipantRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyParticipantRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyParticipantRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets whether the specified person is a participant in the specified ceremony.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>Whether the specified person is a participant in the specified ceremony.</returns>
        public async Task<bool> PersonIsCeremonyParticipant(int personId, int ceremonyId)
        {
            return await this._context.CeremonyParticipants.Where(cp => cp.PersonId == personId && cp.CeremonyId == ceremonyId && !cp.Deleted).AnyAsync();
        }
    }
}