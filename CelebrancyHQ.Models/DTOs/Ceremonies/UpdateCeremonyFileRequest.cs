namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to update a ceremony file.
    /// </summary>
    public class UpdateCeremonyFileRequest
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony file.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description of the file.
        /// </summary>
        public string? Description { get; set; }
    }
}