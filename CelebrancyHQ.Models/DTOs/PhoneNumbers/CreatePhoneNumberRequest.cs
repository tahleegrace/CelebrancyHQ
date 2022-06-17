namespace CelebrancyHQ.Models.DTOs.PhoneNumbers
{
    /// <summary>
    /// Stores details about a request to create a phone number.
    /// </summary>
    public class CreatePhoneNumberRequest
    {
        /// <summary>
        /// Gets or sets the type of the phone number (e.g. mobile, landline, etc).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets whether this is the primary phone number for the person or organisation.
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Gets or sets the description of the phone number.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}