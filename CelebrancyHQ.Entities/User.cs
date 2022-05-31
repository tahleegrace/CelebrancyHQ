using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A user.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [Required]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the password hash of the user.
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the password hash of the user.
        /// </summary>
        [Required]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the person for the user.
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// The ID of the person for the user.
        /// </summary>
        public int PersonId { get; set; }
    }
}