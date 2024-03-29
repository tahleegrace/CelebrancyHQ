﻿using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.Files;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functionality for managing ceremony files.
    /// </summary>
    public interface ICeremonyFileService
    {
        /// <summary>
        /// Gets the files for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The files for the specified ceremony.</returns>
        Task<List<CeremonyFileDTO>> GetCeremonyFiles(int ceremonyId, int currentUserId);

        /// <summary>
        /// Downloads the specified file.
        /// </summary>
        /// <param name="fileId">The ID of the file.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The file to download.</returns>
        Task<DownloadFileDTO> DownloadFile(int fileId, int currentUserId);

        /// <summary>
        /// Creates a new ceremony file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created ceremony file.</returns>
        Task<CeremonyFileDTO> Create(CreateCeremonyFileRequest file, int ceremonyId, int currentUserId);

        /// <summary>
        /// Updates the details of the specified ceremony file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task Update(UpdateCeremonyFileRequest file, int currentUserId);

        /// <summary>
        /// Deletes the specified ceremony file.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task Delete(int id, int currentUserId);
    }
}