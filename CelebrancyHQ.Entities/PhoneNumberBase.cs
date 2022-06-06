using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A phone number.
    /// </summary>
    public abstract class PhoneNumberBase : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the phone number.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the phone number (e.g. mobile, landline, etc).
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the description of the phone number.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
    }
}