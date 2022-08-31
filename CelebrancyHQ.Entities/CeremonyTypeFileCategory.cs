using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A category of file that a ceremony type can have.
    /// </summary>
    public class CeremonyTypeFileCategory : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type file category.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ceremony type.
        /// </summary>
        [Required]
        public CeremonyType CeremonyType { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type.
        /// </summary>
        [Required]
        public int CeremonyTypeId { get; set; }

        /// <summary>
        /// Gets or sets the code of the ceremony type file category.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the permission code of the ceremony type file category.
        /// </summary>
        [Required]
        public string PermissionCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony type file category.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony type file category.
        /// </summary>
        public string? Description { get; set; }
    }
}