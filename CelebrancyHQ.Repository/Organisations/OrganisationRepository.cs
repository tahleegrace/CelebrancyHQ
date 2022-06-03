using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Organisations
{
    /// <summary>
    /// The organisations repository.
    /// </summary>
    public class OrganisationRepository : IOrganisationRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of OrganisationRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public OrganisationRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the organisation with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the organisation.</param>
        /// <returns>The organisation with the specified ID.</returns>
        public async Task<Organisation?> FindById(int id)
        {
            var organisation = await this._context.Organisations.Where(o => o.Id == id && !o.Deleted).FirstOrDefaultAsync();

            return organisation;
        }
    }
}