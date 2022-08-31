using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A file linked to a ceremony.
    /// </summary>
    public class CeremonyFile : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony file.
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
        /// Gets or sets the file category.
        /// </summary>
        [Required]
        public CeremonyTypeFileCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the ID of the file category.
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

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
        /// Gets or sets the description of the file.
        /// </summary>
        public string Description { get; set; }
    }
}