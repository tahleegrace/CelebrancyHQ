using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A question for a ceremony type meeting.
    /// </summary>
    public class CeremonyTypeMeetingQuestion : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type meeting question.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ceremony type meeting.
        /// </summary>
        [Required]
        public CeremonyTypeMeeting CeremonyTypeMeeting { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type meeting.
        /// </summary>
        [Required]
        public int CeremonyTypeMeetingId { get; set; }

        /// <summary>
        /// Gets or sets the question type.
        /// </summary>
        [Required]
        public CeremonyTypeMeetingQuestionType QuestionType { get; set; }

        /// <summary>
        /// Gets or sets the ID of the question type.
        /// </summary>
        [Required]
        public int QuestionTypeId { get; set; }

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        [Required]
        public string Question { get; set; }

        /// <summary>
        /// Gets or sets the description of the question.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets a comma-separated list of the options available for the question (only applicable for dropdown and checkbox question types).
        /// </summary>
        public string? Options { get; set; }

        /// <summary>
        /// Gets or sets whether the question is required.
        /// </summary>
        [Required]
        public bool Required { get; set; }
    }
}