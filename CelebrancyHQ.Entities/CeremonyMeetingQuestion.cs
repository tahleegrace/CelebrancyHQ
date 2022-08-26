using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// An answer to a question in a ceremony meeting.
    /// </summary>
    public class CeremonyMeetingQuestion : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony meeting question.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ceremony meeting.
        /// </summary>
        [Required]
        public CeremonyMeeting CeremonyMeeting { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony meeting.
        /// </summary>
        [Required]
        public int CeremonyMeetingId { get; set; }

        /// <summary>
        /// Gets or sets the ceremony type meeting question.
        /// </summary>
        [Required]
        public CeremonyTypeMeetingQuestion CeremonyTypeMeetingQuestion { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type meeting question.
        /// </summary>
        [Required]
        public int CeremonyTypeMeetingQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the answer to the ceremony question (not applicable for file or image questions).
        /// </summary>
        public string? Answer { get; set; }

        /// <summary>
        /// Gets or sets the file for the question (only applicable for file or image questions).
        /// </summary>
        public File? File { get; set; }

        /// <summary>
        /// Gets or sets the ID of the file for the question (only applicable for file or image questions).
        /// </summary>
        public int? FileId { get; set; }
    }
}