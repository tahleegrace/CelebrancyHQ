using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Files
{
    /// <summary>
    /// The files repository.
    /// </summary>
    public class FileRepository : IFileRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of FileRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public FileRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <returns>The file with the specified ID.</returns>
        public async Task<Entities.File?> FindById(int id)
        {
            return await this._context.Files.Include(f => f.CreatedBy)
                                            .Where(f => f.Id == id && !f.Deleted)
                                            .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>The newly created file.</returns>
        public async Task<Entities.File> Create(Entities.File file)
        {
            file.Created = DateTime.UtcNow;
            file.Updated = DateTime.UtcNow;

            this._context.Files.Add(file);

            await this._context.SaveChangesAsync();

            var newFile = await FindById(file.Id);
            return newFile;
        }
    }
}