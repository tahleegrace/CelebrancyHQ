using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// An individual participant in a ceremony.
    /// </summary>
    public class CeremonyParticipant : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony participant.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ceremony.
        /// </summary>
        [Required]
        public Ceremony Ceremony { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony.
        /// </summary>
        [Required]
        public int CeremonyId { get; set; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        [Required]
        public Person Person { get; set; }

        /// <summary>
        /// Gets or sets the ID of the person.
        /// </summary>
        [Required]
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the ceremony type participant.
        /// </summary>
        [Required]
        public CeremonyTypeParticipant CeremonyTypeParticipant { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type participant.
        /// </summary>
        [Required]
        public int CeremonyTypeParticipantId { get; set; }

        /// <summary>
        /// Gets or sets any notes about the participant.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets whether the ceremony participant has been deleted.
        /// </summary>
        [Required]
        public bool Deleted { get; set; } = false;
    }
}