namespace CelebrancyHQ.Models.DTOs.Addresses
{
    /// <summary>
    /// An address.
    /// </summary>
    public class AddressDTO
    {
        /// <summary>
        /// Gets or sets the ID of the address.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the suburb.
        /// </summary>
        public string Suburb { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; }
    }
}