using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony files repository.
    /// </summary>
    public class CeremonyFileRepository : ICeremonyFileRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyFileRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyFileRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the ceremony file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <returns>The ceremony file with the specified ID.</returns>
        public async Task<CeremonyFile?> FindById(int id)
        {
            return await this._context.CeremonyFiles.Include(cf => cf.File)
                                                    .Include(cf => cf.Category)
                                                    .Where(cf => cf.Id == id && !cf.Deleted)
                                                    .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the files for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The files for the specified ceremony.</returns>
        public async Task<List<CeremonyFile>> GetCeremonyFiles(int ceremonyId)
        {
            return await this._context.CeremonyFiles.Include(cf => cf.File)
                                                    .Include(cf => cf.Category)
                                                    .Where(cf => cf.CeremonyId == ceremonyId && !cf.Deleted)
                                                    .ToListAsync();
        }

        /// <summary>
        /// Creates a new ceremony file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>The newly created ceremony file.</returns>
        public async Task<CeremonyFile> Create(CeremonyFile file)
        {
            file.Created = DateTime.UtcNow;
            file.Updated = DateTime.UtcNow;

            this._context.CeremonyFiles.Add(file);

            await this._context.SaveChangesAsync();

            var newFile = await FindById(file.Id);
            return newFile;
        }

        /// <summary>
        /// Updates the details of the specified ceremony file.
        /// </summary>
        /// <param name="file">The file.</param>
        public async Task Update(CeremonyFile file)
        {
            file.Updated = DateTime.UtcNow;

            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        public async Task Delete(int id)
        {
            var file = await this.FindById(id);
            file.Updated = DateTime.UtcNow;
            file.Deleted = true;
            await this._context.SaveChangesAsync();
        }
    }
}