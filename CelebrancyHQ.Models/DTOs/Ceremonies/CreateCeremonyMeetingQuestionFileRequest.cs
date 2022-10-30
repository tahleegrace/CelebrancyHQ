using CelebrancyHQ.Models.DTOs.Files;

namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to create a ceremony meeting question file.
    /// </summary>
    public class CreateCeremonyMeetingQuestionFileRequest : CreateFileRequest
    {
        /// <summary>
        /// Gets or sets the description of the file.
        /// </summary>
        public string? Description { get; set; }
    }
}