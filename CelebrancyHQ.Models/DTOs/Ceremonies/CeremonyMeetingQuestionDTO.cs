namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a ceremony meeting question.
    /// </summary>
    public class CeremonyMeetingQuestionDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony meeting question.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type question.
        /// </summary>
        public int CeremonyTypeQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the question type code.
        /// </summary>
        public string QuestionTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Gets or sets the description of the question.
        /// </summary>
        public string? QuestionDescription { get; set; }

        /// <summary>
        /// Gets or sets the answer to the question.
        /// </summary>
        public string? Answer { get; set; }
    }
}