namespace CelebrancyHQ.Models.DTOs.Files
{
    /// <summary>
    /// Stores details about a file that can be downloaded.
    /// </summary>
    public class DownloadFileDTO : FileDTO
    {
        /// <summary>
        /// Gets or sets the file data.
        /// </summary>
        public byte[] FileData { get; set; }
    }
}