using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony meeting question files repository.
    /// </summary>
    public interface ICeremonyMeetingQuestionFileRepository
    {
        /// <summary>
        /// Finds the ceremony meeting question file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <returns>The ceremony meeting question file with the specified ID.</returns>
        Task<CeremonyMeetingQuestionFile?> FindById(int id);

        /// <summary>
        /// Gets the ceremony meeting question files for the specified meeting.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <returns>The ceremony meeting question files for the specified meeting.</returns>
        Task<List<CeremonyMeetingQuestionFile>> GetMeetingFiles(int meetingId);

        /// <summary>
        /// Creates a new ceremony meeting question file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>The newly created ceremony meeting question file.</returns>
        Task<CeremonyMeetingQuestionFile> Create(CeremonyMeetingQuestionFile file);

        /// <summary>
        /// Deletes the ceremony meeting question file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        Task Delete(int id);
    }
}