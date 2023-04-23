using System.Dynamic;

using CelebrancyHQ.Models.DTOs.Files;

namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a ceremony file.
    /// </summary>
    public class CeremonyFileDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony file.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets any additional data for the ceremony file.
        /// </summary>
        public dynamic AdditionalData { get; set; } = new ExpandoObject();

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public CeremonyTypeFileCategoryDTO Category { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        public FileDTO File { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony file.
        /// </summary>
        public string? Description { get; set; }
    }
}