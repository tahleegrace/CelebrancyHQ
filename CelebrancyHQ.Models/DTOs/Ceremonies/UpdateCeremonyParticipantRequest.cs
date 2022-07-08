using CelebrancyHQ.Models.DTOs.Persons;

namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to update a ceremony participant.
    /// </summary>
    public class UpdateCeremonyParticipantRequest : UpdatePersonRequest
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony participant.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets any notes about the participant.
        /// </summary>
        public string? Notes { get; set; }
    }
}