using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A type of ceremony that can be offered (such as a wedding or funeral).
    /// </summary>
    public class CeremonyType : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony that can be offered.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the ceremony type.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony that can be offered.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the organisation that the ceremony is restricted to.
        /// 
        /// If an organisation is set - only members of this organisation can offer this ceremony type.
        /// If an organisation is not set - all users of CelebrancyHQ can offer this ceremony type.
        /// </summary>
        public Organisation? Organisation { get; set; }

        /// <summary>
        /// Gets or sets the ID of the organisation that the ceremony is restricted to.
        /// </summary>
        public int? OrganisationId { get; set; }
    }
}