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
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created file.</returns>
        Task<FileDTO> CreateFile(CreateFileRequest file, int currentUserId);
    }
}