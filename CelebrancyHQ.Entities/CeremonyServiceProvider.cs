using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// An individual service provider in a ceremony.
    /// </summary>
    public class CeremonyServiceProvider : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony service provider.
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
        /// Gets or sets the organisation.
        /// </summary>
        [Required]
        public Organisation Organisation { get; set; }

        /// <summary>
        /// Gets or sets the ID of the organisation.
        /// </summary>
        [Required]
        public int OrganisationId { get; set; }

        /// <summary>
        /// Gets or sets the ceremony type service provider.
        /// </summary>
        [Required]
        public CeremonyTypeServiceProvider CeremonyTypeServiceProvider { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type service provider.
        /// </summary>
        [Required]
        public int CeremonyTypeServiceProviderId { get; set; }

        /// <summary>
        /// Gets or sets any notes about the service provider.
        /// </summary>
        public string? Notes { get; set; }
    }
}