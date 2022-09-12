using CelebrancyHQ.Models.DTOs.Core;

namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to update a ceremony meeting.
    /// </summary>
    public class UpdateCeremonyMeetingRequest
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony meeting.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony meeting.
        /// </summary>
        public UpdateFieldRequest<string> Name { get; set; } = new UpdateFieldRequest<string>();

        /// <summary>
        /// Gets or sets the description of the ceremony meeting.
        /// </summary>
        public UpdateFieldRequest<string?> Description { get; set; } = new UpdateFieldRequest<string?>();

        /// <summary>
        /// Gets or sets the date of the ceremony meeting.
        /// </summary>
        public UpdateFieldRequest<DateTime> Date { get; set; } = new UpdateFieldRequest<DateTime>();
    }
}