namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// An event that occurs when the country of an address is updated.
    /// </summary>
    public class AddressCountryUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Country";

        /// <summary>
        /// Creates a new instance of AddressCountryUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old country.</param>
        /// <param name="newValue">The new country.</param>
        public AddressCountryUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}