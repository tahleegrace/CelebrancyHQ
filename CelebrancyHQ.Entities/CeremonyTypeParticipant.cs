using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A participant that a type of ceremony can have (e.g. celebrant, couple, organiser, witnesses, bridal party, invited guest, person who has passed away, other)
    /// </summary>
    public class CeremonyTypeParticipant : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type participant.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ceremony type.
        /// </summary>
        [Required]
        public CeremonyType CeremonyType { get; set; }

        /// <summary>
        /// Gets or sets the ceremony type ID.
        /// </summary>
        [Required]
        public int CeremonyTypeId { get; set; }

        /// <summary>
        /// Gets or sets the code of the ceremony type participant.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony type participant.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony type participant.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets whether the ceremony type participant has been deleted.
        /// </summary>
        [Required]
        public bool Deleted { get; set; } = false;
    }
}