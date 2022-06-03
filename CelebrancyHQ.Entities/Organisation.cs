using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// An organisation.
    /// </summary>
    public class Organisation : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the organisation.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the organisation.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether the organisation has been deleted.
        /// </summary>
        [Required]
        public bool Deleted { get; set; } = false;
    }
}