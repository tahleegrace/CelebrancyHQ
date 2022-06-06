using System.ComponentModel.DataAnnotations;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A phone number for a person.
    /// </summary>
    public class PersonPhoneNumber : PhoneNumberBase
    {
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
    }
}