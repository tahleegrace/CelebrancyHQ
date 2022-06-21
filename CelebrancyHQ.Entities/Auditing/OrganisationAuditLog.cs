using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities.Auditing
{
    /// <summary>
    /// An audit log for an organisation.
    /// </summary>
    public class OrganisationAuditLog : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the audit log.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        /// Gets or sets the person who made changes to the organisation.
        /// </summary>
        [Required]
        public Person Person { get; set; }

        /// <summary>
        /// Gets or sets the ID of the person who made changes to the organisation.
        /// </summary>
        [Required]
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        [Required]
        public string Event { get; set; }
    }
}