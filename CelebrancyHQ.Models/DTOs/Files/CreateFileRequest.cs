namespace CelebrancyHQ.Models.DTOs.Files
{
    /// <summary>
    /// Stores details about a request to create a file.
    /// </summary>
    public class CreateFileRequest
    {
        /// <summary>
        /// Gets or sets the file data.
        /// </summary>
        public IFormFile FileData { get; set; }
    }
}