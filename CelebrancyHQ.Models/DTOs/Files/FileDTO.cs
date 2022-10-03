using CelebrancyHQ.Models.DTOs.Persons;

namespace CelebrancyHQ.Models.DTOs.Files
{
    /// <summary>
    /// Stores details about a file.
    /// </summary>
    public class FileDTO
    {
        /// <summary>
        /// Gets or sets the ID of the file.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content type of the file.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Gets or sets the person who created the file.
        /// </summary>
        public PersonDTO CreatedBy { get; set; }
    }
}