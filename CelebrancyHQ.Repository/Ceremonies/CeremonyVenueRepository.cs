using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony venues repository.
    /// </summary>
    public class CeremonyVenueRepository : ICeremonyVenueRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyVenueRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyVenueRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the primary venues for the specified ceremonies.
        /// </summary>
        /// <param name="ceremonyIds">The IDs of the ceremonies.</param>
        /// <returns>The primary venues for the specified ceremonies.</returns>
        public async Task<Dictionary<int, Organisation>> GetPrimaryVenuesForCeremonies(List<int> ceremonyIds)
        {
            return await this._context.CeremonyVenues.Include(cv => cv.Organisation)
                                                     .Include(cv => cv.Organisation.Address)
                                                     .Where(cv => ceremonyIds.Contains(cv.CeremonyId) && !cv.Deleted && cv.IsPrimary)
                                                     .ToDictionaryAsync(cv => cv.CeremonyId, cv => cv.Organisation);
        }
    }
}