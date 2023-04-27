using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Files;

namespace CelebrancyHQ.Services.Files
{
    /// <summary>
    /// A service that provides functions for managing files.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="currentUser">The current user.</param>
        /// <returns>The newly created file.</returns>
        Task<FileDTO> Create(CreateFileRequest file, Person currentUser);

        /// <summary>
        /// Downloads the specified file.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <returns>The file to download.</returns>
        Task<DownloadFileDTO> DownloadFile(int id);

        /// <summary>
        /// Deletes the file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        Task Delete(int id);
    }
}