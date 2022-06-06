using System.ComponentModel.DataAnnotations;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A phone number for an organisation.
    /// </summary>
    public class OrganisationPhoneNumber : PhoneNumberBase
    {
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
    }
}