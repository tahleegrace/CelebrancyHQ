namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to create a ceremony meeting.
    /// </summary>
    public class CreateCeremonyMeetingRequest
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type meeting.
        /// </summary>
        public int CeremonyTypeMeetingId { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony meeting.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the date of the ceremony meeting.
        /// </summary>
        public DateTime Date { get; set; }
    }
}