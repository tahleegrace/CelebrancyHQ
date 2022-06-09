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
        /// Gets or sets the event.
        /// </summary>
        [Required]
        [JsonField]
        public AuditEvent Event { get; set; }
    }
}