using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.CeremonyTypes
{
    /// <summary>
    /// The ceremony type service providers repository.
    /// </summary>
    public class CeremonyTypeServiceProviderRepository : ICeremonyTypeServiceProviderRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeServiceProviderRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyTypeServiceProviderRepository(CelebrancyHQContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Finds the ceremony type service provider for the specified ceremony type with the specified code.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="code">The code of the ceremony type service provider.</param>
        /// <returns>The ceremony type service provider for the specified ceremony type with the specified code.</returns>
        public async Task<CeremonyTypeServiceProvider?> FindByCode(int ceremonyTypeId, string code)
        {
            return await _context.CeremonyTypeServiceProviders.Where(tsp => tsp.CeremonyTypeId == ceremonyTypeId && tsp.Code == code && !tsp.Deleted)
                                                                   .FirstOrDefaultAsync();
        }
    }
}