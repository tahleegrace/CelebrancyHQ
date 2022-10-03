namespace CelebrancyHQ.Repository.Files
{
    /// <summary>
    /// A files repository.
    /// </summary>
    public interface IFileRepository
    {
        /// <summary>
        /// Finds the file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <returns>The file with the specified ID.</returns>
        Task<Entities.File?> FindById(int id);

        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>The newly created file.</returns>
        Task<Entities.File> Create(Entities.File file);
    }
}