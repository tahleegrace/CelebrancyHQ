using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A type of question for a ceremony type meeting.
    /// </summary>
    public class CeremonyTypeMeetingQuestionType : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type meeting question type.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code of the ceremony type meeting question type.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony type meeting question type.
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}