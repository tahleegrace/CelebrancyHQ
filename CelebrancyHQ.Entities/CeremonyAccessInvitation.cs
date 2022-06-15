using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// Stores details about an invitation to access a ceremony.
    /// </summary>
    public class CeremonyAccessInvitation : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony access invitation.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ceremony participant the access invitation is attached to.
        /// </summary>
        [Required]
        public CeremonyParticipant CeremonyParticipant { get; set; }

        /// <summary>
        /// Gets or sets the ceremony participant the access invitation is attached to.
        /// </summary>
        [Required]
        public int CeremonyParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the unique code used to access the invitation.
        /// </summary>
        [Required]
        public string UniqueCode { get; set; }

        /// <summary>
        /// Gets or sets whether the access invitation has been accepted.
        /// </summary>
        [Required]
        public bool Accepted { get; set; }
    }
}