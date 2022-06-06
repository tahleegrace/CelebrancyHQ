using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremonies repository.
    /// </summary>
    public class CeremonyRepository : ICeremonyRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets all of the ceremonies for the specified person with the specified participant type between the specified dates.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="participantTypeIds">The ID of the participant types.</param>
        /// <param name="from">The from date.</param>
        /// <param name="to">The to date.</param>
        /// <returns>The ceremonies matching the specified criteria.</returns>
        public async Task<List<Ceremony>> GetAll(int personId, List<int> participantTypeIds, DateTime? from, DateTime? to)
        {
            var participantsQuery = this._context.CeremonyParticipants.Where(cp => cp.PersonId == personId && !cp.Deleted);

            if (participantTypeIds.Count > 0)
            {
                participantsQuery = participantsQuery.Where(cp => participantTypeIds.Contains(cp.CeremonyTypeParticipantId));
            }

            var ceremonyIds = await participantsQuery.Select(cp => cp.CeremonyId).Distinct().ToListAsync();
            var ceremoniesQuery = this._context.Ceremonies.Where(c => ceremonyIds.Contains(c.Id) && !c.Deleted);

            if (from != null)
            {
                ceremoniesQuery = ceremoniesQuery.Where(c => c.CeremonyDate >= from);
            }

            if (to != null)
            {
                ceremoniesQuery = ceremoniesQuery.Where(c => c.CeremonyDate <= to);
            }

            return await ceremoniesQuery.ToListAsync();
        }

        /// <summary>
        /// Gets the ceremony with the specified ID.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The ceremony with the specified ID.</returns>
        public async Task<Ceremony?> FindById(int ceremonyId)
        {
            return await this._context.Ceremonies.Include(c => c.CeremonyType)
                                                 .Where(c => c.Id == ceremonyId && !c.Deleted)
                                                 .FirstOrDefaultAsync();
        }
    }
}