using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A participant in a ceremony meeting.
    /// </summary>
    public class CeremonyMeetingParticipant : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony meeting participant.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ceremony meeting.
        /// </summary>
        [Required]
        public CeremonyMeeting CeremonyMeeting { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony meeting.
        /// </summary>
        [Required]
        public int CeremonyMeetingId { get; set; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        [Required]
        public Person Person { get; set; }

        /// <summary>
        /// Gets or sets the ID of the person.
        /// </summary>
        [Required]
        public int PersonId { get; set; }
    }
}