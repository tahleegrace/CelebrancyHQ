using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// Details about a venue a ceremony is hosted at.
    /// </summary>
    public class CeremonyVenue : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the venue.
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
        /// Gets or sets the organisation the ceremony is hosted at.
        /// </summary>
        [Required]
        public Organisation Organisation { get; set; }

        /// <summary>
        /// Gets or sets the ID of the organisation the ceremony is hosted at.
        /// </summary>
        [Required]
        public int OrganisationId { get; set; }

        /// <summary>
        /// Gets or sets the name of the venue (e.g. wedding ceremony, reception etc).
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether this is the primary venue or venue where the participants for the ceremony first meet.
        /// </summary>
        [Required]
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Gets or sets any notes about the venue.
        /// </summary>
        public string? Notes { get; set; }
    }
}