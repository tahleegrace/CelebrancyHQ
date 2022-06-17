using CelebrancyHQ.Models.DTOs.Addresses;
using CelebrancyHQ.Models.DTOs.PhoneNumbers;

namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about a request to create a ceremony participant.
    /// </summary>
    public class CreateCeremonyParticipantRequest
    {
        /// <summary>
        /// Gets or sets the code of the ceremony type participant.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the first name of the participant.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle names of the participant.
        /// </summary>
        public string? MiddleNames { get; set; }

        /// <summary>
        /// Gets or sets the last name of the participant.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the preferred name of the participant.
        /// </summary>
        public string? PreferredName { get; set; }

        /// <summary>
        /// Gets or sets the title of the participant.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the gender of the participant.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the email address of the participant.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers of the participant.
        /// </summary>
        public List<CreatePhoneNumberRequest> PhoneNumbers { get; set; } = new List<CreatePhoneNumberRequest>();

        /// <summary>
        /// Gets or sets the address of the participant.
        /// </summary>
        public CreateAddressRequest? Address { get; set; }
    }
}