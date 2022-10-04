using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony files repository.
    /// </summary>
    public interface ICeremonyFileRepository
    {
        /// <summary>
        /// Finds the ceremony file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <returns>The ceremony file with the specified ID.</returns>
        Task<CeremonyFile?> FindById(int id);

        /// <summary>
        /// Creates a new ceremony file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>The newly created ceremony file.</returns>
        Task<CeremonyFile> Create(CeremonyFile file);
    }
}