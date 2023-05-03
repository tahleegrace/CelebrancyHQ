using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.CeremonyTypes
{
    /// <summary>
    /// The ceremony type date repository.
    /// </summary>
    public class CeremonyTypeDateRepository : ICeremonyTypeDateRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeDateRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyTypeDateRepository(CelebrancyHQContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Finds the ceremony type date for the specified ceremony type and code.
        /// </summary>
        /// <param name="code">The code of the ceremony type.</param>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <returns>The ceremony type date with the specified code.</returns>
        public async Task<CeremonyTypeDate?> FindByCode(string code, int ceremonyTypeId)
        {
            return await _context.CeremonyTypeDates.Where(ctd => ctd.Code == code && ctd.CeremonyTypeId == ceremonyTypeId && !ctd.Deleted)
                                                        .FirstOrDefaultAsync();
        }
    }
}