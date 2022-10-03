namespace CelebrancyHQ.Models.DTOs.Files
{
    /// <summary>
    /// Stores details about a request to create a file.
    /// </summary>
    public class CreateFileRequest
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content type of the file.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the file data.
        /// </summary>
        public byte[] FileData { get; set; }
    }
}