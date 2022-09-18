namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to update a ceremony meeting question.
    /// </summary>
    public class UpdateCeremonyMeetingQuestionRequest
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type question.
        /// </summary>
        public int CeremonyTypeQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the answer to the question.
        /// </summary>
        public string? Answer { get; set; }
    }
}