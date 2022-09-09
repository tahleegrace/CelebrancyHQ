using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A meeting hosted to discuss a ceremony.
    /// </summary>
    public class CeremonyMeeting : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony meeting.
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
        /// Gets or sets the ceremony type meeting.
        /// </summary>
        [Required]
        public CeremonyTypeMeeting CeremonyTypeMeeting { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type meeting.
        /// </summary>
        [Required]
        public int CeremonyTypeMeetingId { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony meeting.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony meeting.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the date of the ceremony meeting.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
    }
}