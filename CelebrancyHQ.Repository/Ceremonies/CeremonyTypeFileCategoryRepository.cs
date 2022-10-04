using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony type file categories repository.
    /// </summary>
    public class CeremonyTypeFileCategoryRepository : ICeremonyTypeFileCategoryRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeFileCategoryRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyTypeFileCategoryRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the ceremony type file category with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the ceremony type file category.</param>
        /// <returns>The ceremony type file category with the specified ID.</returns>
        public async Task<CeremonyTypeFileCategory?> FindById(int id)
        {
            return await this._context.CeremonyTypeFileCategories.Where(ctfc => ctfc.Id == id && !ctfc.Deleted)
                                                                 .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Finds the file category for the specified ceremony type with the specified code.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="code">The code of the file category.</param>
        /// <returns>The file category for the specified ceremony type with the specified code.</returns>
        public async Task<CeremonyTypeFileCategory?> FindByCode(int ceremonyTypeId, string code)
        {
            return await this._context.CeremonyTypeFileCategories.Where(ctfc => ctfc.CeremonyTypeId == ceremonyTypeId && ctfc.Code == code && !ctfc.Deleted)
                                                                 .FirstOrDefaultAsync();
        }
    }
}