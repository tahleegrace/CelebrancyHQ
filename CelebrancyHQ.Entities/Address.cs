using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// An address.
    /// </summary>
    public class Address: BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the address.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        [Required]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the suburb.
        /// </summary>
        [Required]
        public string Suburb { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [Required]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        [Required]
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets whether the address has been deleted.
        /// </summary>
        [Required]
        public bool Deleted { get; set; } = false;
    }
}