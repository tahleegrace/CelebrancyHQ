namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to update a ceremony date.
    /// </summary>
    public class UpdateCeremonyDateRequest
    {
        /// <summary>
        /// The ID of the ceremony date.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date.
        /// </summary>
        public DateTime Date { get; set; }
    }
}