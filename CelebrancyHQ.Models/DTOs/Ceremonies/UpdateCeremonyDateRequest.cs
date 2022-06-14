namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to update a ceremony date.
    /// </summary>
    public class UpdateCeremonyDateRequest
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony date.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the code of the ceremony date.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }
    }
}