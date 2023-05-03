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
    }
}