using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony types repository.
    /// </summary>
    public class CeremonyTypeRepository : ICeremonyTypeRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyTypeRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the ceremony types that can be offered by the specified organisation.
        /// </summary>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <returns>The ceremony types that can be offered by the specified organisation.</returns>
        public async Task<List<CeremonyType>> FindByOrganisationId(int? organisationId)
        {
            List<CeremonyType> ceremonyTypes;

            if (organisationId == null)
            {
                ceremonyTypes = await this._context.CeremonyTypes.Where(t => t.OrganisationId == null).ToListAsync();
            }
            else
            {
                ceremonyTypes = await this._context.CeremonyTypes.Where(t => t.OrganisationId == organisationId || t.OrganisationId == null).ToListAsync();
            }

            return ceremonyTypes;
        }
    }
}