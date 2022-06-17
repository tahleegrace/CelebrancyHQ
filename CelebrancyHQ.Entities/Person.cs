using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A person.
    /// </summary>
    public class Person : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the person.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle names of the person.
        /// </summary>
        public string? MiddleNames { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the preferred name of the person.
        /// </summary>
        public string? PreferredName { get; set; }

        /// <summary>
        /// Gets or sets the title of the person.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the gender the person identifies as.
        /// </summary>
        [Required]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the email address of the person.
        /// </summary>
        [Required]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the address of the person.
        /// </summary>
        [JsonIgnore]
        public Address? Address { get; set; }

        /// <summary>
        /// Gets or sets the ID of the address of the person.
        /// </summary>
        [JsonIgnore]
        public int? AddressId { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the person.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the organisation of the person.
        /// </summary>
        [JsonIgnore]
        public Organisation? Organisation { get; set; }

        /// <summary>
        /// Gets or sets the organisation ID of the person.
        /// </summary>
        [JsonIgnore]
        public int? OrganisationId { get; set; }

        /// <summary>
        /// Gets or sets whether the user has been registered.
        /// </summary>
        [Required]
        public bool Registered { get; set; }
    }
}