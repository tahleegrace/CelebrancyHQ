using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A file attached to an answer to ceremony meeting question.
    /// </summary>
    public class CeremonyMeetingQuestionFile : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony meeting question.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        [Required]
        public CeremonyMeetingQuestion Question { get; set; }

        /// <summary>
        /// Gets or sets the ID of the question.
        /// </summary>
        [Required]
        public int QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        [Required]
        public CeremonyFile File { get; set; }

        /// <summary>
        /// Gets or sets the ID of the file.
        /// </summary>
        [Required]
        public int FileId { get; set; }
    }
}