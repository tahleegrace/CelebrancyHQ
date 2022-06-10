using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// The permissions a ceremony type participant has on an individual ceremony.
    /// </summary>
    public class CeremonyPermission : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony permission.
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
        /// Gets or sets the field that the permission is for.
        /// </summary>
        [Required]
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets whether the participant can view the field.
        /// </summary>
        [Required]
        public bool CanView { get; set; }

        /// <summary>
        /// Gets or sets whether the participant can edit the field.
        /// </summary>
        [Required]
        public bool CanEdit { get; set; }

        /// <summary>
        /// Gets or sets whether the participant can edit the field with approval from other approvers.
        /// </summary>
        [Required]
        public bool CanEditWithApproval { get; set; }

        /// <summary>
        /// Gets or sets whether the participant is an approver for this field.
        /// </summary>
        [Required]
        public bool IsApprover { get; set; }

        /// <summary>
        /// Gets or sets whether the participant can view the history of this field.
        /// </summary>
        [Required]
        public bool CanViewHistory { get; set; }
    }
}