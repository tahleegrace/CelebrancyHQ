using Innofactor.EfCoreJsonValueConverter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities.Auditing
{
    /// <summary>
    /// An audit log for a ceremony.
    /// </summary>
    public class CeremonyAuditLog : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the audit log.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the ceremony.
        /// </summary>
        [Required]
        public Ceremony Ceremony { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony.
        /// </summary>
        [Required]
        public int CeremonyId { get; set; }

        /// <summary>
        /// Gets or sets the person who made changes to the ceremony.
        /// </summary>
        [Required]
        public Person Person { get; set; }

        /// <summary>
        /// Gets or sets the ID of the person who made changes to the ceremony.
        /// </summary>
        [Required]
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        [Required]
        [JsonField]
        public List<AuditEvent> Event { get; set; }
    }
}