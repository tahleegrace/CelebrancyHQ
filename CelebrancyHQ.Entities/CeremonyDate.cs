using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// An individual date for a ceremony.
    /// </summary>
    public class CeremonyDate : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony date.
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
        /// Gets or sets the ceremony type date.
        /// </summary>
        [Required]
        public CeremonyTypeDate CeremonyTypeDate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type date.
        /// </summary>
        [Required]
        public int CeremonyTypeDateId { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets any notes about the ceremony date.
        /// </summary>
        public string? Notes { get; set; }
    }
}