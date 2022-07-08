using CelebrancyHQ.Models.DTOs.Addresses;
using CelebrancyHQ.Models.DTOs.PhoneNumbers;

namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to create a ceremony service provider.
    /// </summary>
    public class CreateCeremonyServiceProviderRequest
    {
        /// <summary>
        /// Gets or sets the code of the ceremony type service provider.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the service provider.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the service provider.
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the web site of the service provider.
        /// </summary>
        public string? Website { get; set; }

        /// <summary>
        /// Gets or sets any notes about the service provider.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers of the organisation.
        /// </summary>
        public List<CreatePhoneNumberRequest> PhoneNumbers { get; set; } = new List<CreatePhoneNumberRequest>();

        /// <summary>
        /// Gets or sets the address of the service provider.
        /// </summary>
        public CreateOrUpdateAddressRequest? Address { get; set; }
    }
}