using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functionality for managing ceremony meeting question files.
    /// </summary>
    public interface ICeremonyMeetingQuestionFileService
    {
        /// <summary>
        /// Gets the files for the specified ceremony meeting.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The files for the specified ceremony meeting.</returns>
        Task<List<CeremonyFileDTO>> GetMeetingFiles(int meetingId, int currentUserId);

        /// <summary>
        /// Creates a new ceremony meeting question file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="questionId">The ID of the ceremony meeting question.</param>
        /// <returns>The newly created ceremony file.</returns>
        Task<CeremonyFileDTO> Create(CreateCeremonyMeetingQuestionFileRequest file, int questionId, int currentUserId);

        /// <summary>
        /// Deletes the specified ceremony meeting question file.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task Delete(int id, int currentUserId);
    }
}