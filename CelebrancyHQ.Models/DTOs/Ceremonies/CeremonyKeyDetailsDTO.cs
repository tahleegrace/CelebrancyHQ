using CelebrancyHQ.Models.DTOs.Organisations;

namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a ceremony to be displayed on the key details tab of the ceremony details page.
    /// </summary>
    public class CeremonyKeyDetailsDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type.
        /// </summary>
        public int CeremonyTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony type.
        /// </summary>
        public string CeremonyTypeName { get; set; }

        /// <summary>
        /// Gets or sets the code of the ceremony type.
        /// </summary>
        public string CeremonyTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the ceremony date.
        /// </summary>
        public DateTime CeremonyDate { get; set; }

        /// <summary>
        /// Gets or sets the first venue the ceremony is hosted at.
        /// </summary>
        public OrganisationKeyDetailsDTO PrimaryVenue { get; set; }

        /// <summary>
        /// Gets or sets the participants for the ceremony.
        /// </summary>
        public List<CeremonyParticipantDTO> Participants { get; set; }

        /// <summary>
        /// Gets or sets the effective permissions for the current person in the ceremony.
        /// </summary>
        public List<CeremonyPermissionDTO> EffectivePermissions { get; set; }
    }
}