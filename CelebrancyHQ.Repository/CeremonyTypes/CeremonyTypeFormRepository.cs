using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.CeremonyTypes
{
    /// <summary>
    /// The ceremony type form repository.
    /// </summary>
    public class CeremonyTypeFormRepository : ICeremonyTypeFormRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeFormRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyTypeFormRepository(CelebrancyHQContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the ceremony type form with the specified ID.
        /// </summary>
        /// <param name="formId">The ID of the form.</param>
        /// <returns>The ceremony type form with the specified ID.</returns>
        public async Task<CeremonyTypeForm?> FindById(int formId)
        {
            return await this._context.CeremonyTypeForms.Where(ctf => ctf.Id == formId && !ctf.Deleted).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Finds the ceremony type forms that can be offered by the specified organisation.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <returns>The ceremony type forms that can be offered by the specified organisation for the specified ceremony type.</returns>
        public async Task<List<CeremonyTypeForm>> FindByOrganisationId(int ceremonyTypeId, int? organisationId)
        {
            List<CeremonyTypeForm> forms;

            if (organisationId == null)
            {
                forms = await _context.CeremonyTypeForms.Where(t => t.OrganisationId == null && !t.Deleted).ToListAsync();
            }
            else
            {
                forms = await _context.CeremonyTypeForms.Where(t => (t.OrganisationId == organisationId || t.OrganisationId == null) && !t.Deleted).ToListAsync();
            }

            return forms;
        }
    }
}