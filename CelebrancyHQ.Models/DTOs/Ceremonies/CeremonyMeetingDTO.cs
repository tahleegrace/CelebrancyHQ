namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a ceremony meeting.
    /// </summary>
    public class CeremonyMeetingDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony meeting.
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