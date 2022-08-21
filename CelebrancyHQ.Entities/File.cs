using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A file.
    /// </summary>
    public class File : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the file.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the content type of the file.
        /// </summary>
        [Required]
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        [Required]
        public long Size { get; set; }

        /// <summary>
        /// Gets or sets the file data.
        /// </summary>
        [Required]
        public byte[] FileData { get; set; }

        /// <summary>
        /// Gets or sets the person who created the file.
        /// </summary>
        [Required]
        public Person CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the ID of the person who created the file.
        /// </summary>
        [Required]
        public int CreatedById { get; set; }
    }
}