namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to update a ceremony.
    /// </summary>
    public class UpdateCeremonyRequest
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony.
        /// </summary>
        public string Name { get; set; }
    }
}