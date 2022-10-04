using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities.Auditing
{
    /// <summary>
    /// An audit log for a file.
    /// </summary>
    public class FileAuditLog : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the audit log.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        [Required]
        public File File { get; set; }

        /// <summary>
        /// Gets or sets the ID of the file.
        /// </summary>
        [Required]
        public int FileId { get; set; }

        /// <summary>
        /// Gets or sets the person who made changes to the file.
        /// </summary>
        [Required]
        public Person Person { get; set; }

        /// <summary>
        /// Gets or sets the ID of the person who made changes to the file.
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