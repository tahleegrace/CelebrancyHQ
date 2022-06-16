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