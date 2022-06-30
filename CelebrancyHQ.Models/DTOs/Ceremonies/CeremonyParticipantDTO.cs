using CelebrancyHQ.Models.DTOs.Persons;

namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about an individual participant in a ceremony.
    /// </summary>
    public class CeremonyParticipantDTO : PersonDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony participant.
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
        /// Gets or sets any notes about the participant.
        /// </summary>
        public string? Notes { get; set; }
    }
}