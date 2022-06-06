using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// An organisation.
    /// </summary>
    public class Organisation : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the organisation.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the organisation (e.g. a venue, celebrant's business or organisation, etc).
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the organisation.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the organisation.
        /// </summary>
        public Address? Address { get; set; }

        /// <summary>
        /// Gets or sets the ID of the address of the organisation.
        /// </summary>
        public int? AddressId { get; set; }

        /// <summary>
        /// Gets or sets the email address of the organisation.
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the web site of the organisation.
        /// </summary>
        public string? Website { get; set; }

        /// <summary>
        /// Gets or sets any additional notes about the organisation.
        /// </summary>
        public string? Notes { get; set; }
    }
}