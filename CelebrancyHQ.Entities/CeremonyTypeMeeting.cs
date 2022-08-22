using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A type of meeting that a ceremony can have.
    /// </summary>
    public class CeremonyTypeMeeting : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type meeting.
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
        /// Gets or sets the template the meeting is based on.
        /// </summary>
        public CeremonyTypeMeeting? Template { get; set; }

        /// <summary>
        /// Gets or sets the ID of the template the meeting is based on.
        /// </summary>
        public int? TemplateId { get; set; }

        /// <summary>
        /// Gets or sets the name of the meeting.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the meeting.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description of the meeting.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the organisation that the meeting is restricted to.
        /// 
        /// If an organisation is set - this is a meeting template for an organisation.
        /// If an organisation is not set - this is a system wide template for a ceremony type meeting.
        /// </summary>
        public Organisation? Organisation { get; set; }

        /// <summary>
        /// Gets or sets the ID of the organisation that the meeting is restricted to.
        /// </summary>
        public int? OrganisationId { get; set; }
    }
}