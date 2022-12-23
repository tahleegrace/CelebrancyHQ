using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functionality for managing ceremony meeting question files.
    /// </summary>
    public interface ICeremonyMeetingQuestionFileService
    {
        /// <summary>
        /// Gets the files for the specified question.
        /// </summary>
        /// <param name="questionId">The ID of the question.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The files for the specified question.</returns>
        Task<List<CeremonyFileDTO>> GetQuestionFiles(int questionId, int currentUserId);

        /// <summary>
        /// Creates a new ceremony meeting question file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="questionId">The ID of the ceremony meeting question.</param>
        /// <returns>The newly created ceremony file.</returns>
        Task<CeremonyFileDTO> Create(CreateCeremonyMeetingQuestionFileRequest file, int questionId, int currentUserId);
    }
}