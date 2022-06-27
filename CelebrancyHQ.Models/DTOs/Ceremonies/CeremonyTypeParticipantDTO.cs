namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores information about a ceremony type participant.
    /// </summary>
    public class CeremonyTypeParticipantDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type participant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code of the ceremony type participant.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony type participant.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony type participant.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of required participants for this participant type.
        /// </summary>
        public int? MinimumNumberOfParticipants { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of participants a ceremony type can have for this participant type.
        /// </summary>
        public int? MaximumNumberOfParticipants { get; set; }

        /// <summary>
        /// Gets or sets whether an address needs to be provided for this participant type.
        /// </summary>
        public bool RequiresAddress { get; set; }

        /// <summary>
        /// Gets or sets whether a phone number needs to be provided for this participant type.
        /// </summary>
        public bool RequiresPhoneNumber { get; set; }
    }
}