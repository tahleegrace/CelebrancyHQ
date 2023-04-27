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
        /// Gets the files for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The files for the specified ceremony.</returns>
        Task<List<CeremonyFile>> GetCeremonyFiles(int ceremonyId);

        /// <summary>
        /// Creates a new ceremony file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>The newly created ceremony file.</returns>
        Task<CeremonyFile> Create(CeremonyFile file);

        /// <summary>
        /// Updates the details of the specified ceremony file.
        /// </summary>
        /// <param name="file">The file.</param>
        Task Update(CeremonyFile file);

        /// <summary>
        /// Deletes the file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        Task Delete(int id);
    }
}