using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A ceremony.
    /// </summary>
    public class Ceremony : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date of the ceremony.
        /// </summary>
        [Required]
        public DateTime CeremonyDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the ceremony.
        /// </summary>
        [Required]
        public CeremonyType CeremonyType { get; set; } 

        /// <summary>
        /// Gets or sets the ID of the ceremony type.
        /// </summary>
        [Required]
        public int CeremonyTypeId { get; set; }

        /// <summary>
        /// Gets or sets any additional notes for the ceremony.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets whether the ceremony has been deleted.
        /// </summary>
        [Required]
        public bool Deleted { get; set; } = false;
    }
}