using CelebrancyHQ.Models.DTOs.Addresses;

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
        /// Gets or sets the name of the ceremony type.
        /// </summary>
        public string CeremonyTypeName { get; set; }

        /// <summary>
        /// Gets or sets the ceremony date.
        /// </summary>
        public DateTime CeremonyDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the first venue the ceremony is hosted at.
        /// </summary>
        public string PrimaryVenueName { get; set; }

        /// <summary>
        /// Gets the address of the first venue the ceremony is hosted at.
        /// </summary>
        public AddressDTO PrimaryVenueAddress { get; set; }
    }
}