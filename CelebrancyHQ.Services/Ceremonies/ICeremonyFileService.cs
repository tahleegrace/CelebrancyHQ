using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functionality for managing ceremony files.
    /// </summary>
    public interface ICeremonyFileService
    {
        /// <summary>
        /// Creates a new ceremony file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The newly created ceremony file.</returns>
        Task<CeremonyFileDTO> Create(CreateCeremonyFileRequest file, int ceremonyId, int currentUserId);
    }
}