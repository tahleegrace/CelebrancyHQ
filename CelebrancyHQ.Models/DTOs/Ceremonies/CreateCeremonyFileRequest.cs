using CelebrancyHQ.Models.DTOs.Files;

namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to create a ceremony file.
    /// </summary>
    public class CreateCeremonyFileRequest : CreateFileRequest
    {
        /// <summary>
        /// Gets or sets the category ID.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the description of the file.
        /// </summary>
        public string? Description { get; set; }
    }
}