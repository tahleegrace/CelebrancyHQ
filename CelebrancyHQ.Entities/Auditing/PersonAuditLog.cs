using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities.Auditing
{
    /// <summary>
    /// An audit log for a person.
    /// </summary>
    public class PersonAuditLog : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the audit log.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the person the audit log is for.
        /// </summary>
        [Required]
        public Person Person { get; set; }

        /// <summary>
        /// Gets or sets the ID of the person the audit log is for.
        /// </summary>
        [Required]
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the person who made changes to the person this audit log is for.
        /// </summary>
        [Required]
        public Person UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the ID of the person who made changes to the person this audit log is for.
        /// </summary>
        [Required]
        public int UpdatedById { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        [Required]
        public string Event { get; set; }
    }
}