using CelebrancyHQ.Models.DTOs.Addresses;

namespace CelebrancyHQ.Models.DTOs.Organisations
{
    /// <summary>
    /// Stores key details about an organisation.
    /// </summary>
    public class OrganisationKeyDetailsDTO
    {
        /// <summary>
        /// Gets or sets the ID of the organisation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the organisation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the organisation.
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the primary phone number of the organisation.
        /// </summary>
        public string? PrimaryPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the address of the organisation.
        /// </summary>
        public AddressDTO? Address { get; set; }
    }
}