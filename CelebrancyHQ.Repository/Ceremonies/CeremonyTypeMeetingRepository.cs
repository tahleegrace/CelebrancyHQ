using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony type meeting repository.
    /// </summary>
    public class CeremonyTypeMeetingRepository : ICeremonyTypeMeetingRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeMeetingRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyTypeMeetingRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the ceremony type meeting with the specified ID.
        /// </summary>
        /// <param name="ceremonyTypeMeetingId">The ID of the ceremony type meeting.</param>
        /// <returns>The ceremony type meeting with the specified ID.</returns>
        public async Task<CeremonyTypeMeeting?> FindById(int ceremonyTypeMeetingId)
        {
            return await this._context.CeremonyTypeMeetings.Where(ctm => ctm.Id == ceremonyTypeMeetingId && !ctm.Deleted).FirstOrDefaultAsync();
        }
    }
}