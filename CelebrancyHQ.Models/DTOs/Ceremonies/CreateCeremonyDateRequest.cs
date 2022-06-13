namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to create a ceremony date.
    /// </summary>
    public class CreateCeremonyDateRequest
    {
        /// <summary>
        /// Gets or sets the name of the date.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets any notes about the date.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }
    }
}