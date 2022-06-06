using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A date that a type of ceremony can have (e.g. ceremony date, rehearsal date, initial phone call, initial interview, reception,other, etc)
    /// </summary>
    public class CeremonyTypeDate : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type date.
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
        /// Gets or sets the ceremony type ID.
        /// </summary>
        [Required]
        public int CeremonyTypeId { get; set; }

        /// <summary>
        /// Gets or sets the code of the ceremony type date.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony type date.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony type date.
        /// </summary>
        public string? Description { get; set; }
    }
}