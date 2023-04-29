using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A type of form a ceremony can have.
    /// </summary>
    public class CeremonyTypeForm : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type form.
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
        /// Gets or sets the template the form is based on.
        /// </summary>
        public CeremonyTypeForm? Template { get; set; }

        /// <summary>
        /// Gets or sets the ID of the template the form is based on.
        /// </summary>
        public int? TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the name of the form.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the form.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description of the form.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the organisation that the form is restricted to.
        /// 
        /// If an organisation is set - this is a form template for an organisation.
        /// If an organisation is not set - this is a system wide template for a ceremony type form.
        /// </summary>
        public Organisation? Organisation { get; set; }

        /// <summary>
        /// Gets or sets the ID of the organisation that the form is restricted to.
        /// </summary>
        public int? OrganisationId { get; set; }
    }
}