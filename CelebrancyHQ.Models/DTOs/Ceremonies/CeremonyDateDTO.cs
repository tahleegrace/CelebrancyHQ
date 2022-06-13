namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about an individual date for a ceremony.
    /// </summary>
    public class CeremonyDateDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony date.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code of the ceremony type date.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony type date.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets any notes about the ceremony date.
        /// </summary>
        public string? Notes { get; set; }
    }
}