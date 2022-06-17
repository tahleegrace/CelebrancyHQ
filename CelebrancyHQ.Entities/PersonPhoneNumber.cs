using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

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
        [JsonIgnore]
        public Person Person { get; set; }

        /// <summary>
        /// Gets or sets the ID of the person.
        /// </summary>
        [Required]
        [JsonIgnore]
        public int PersonId { get; set; }
    }
}