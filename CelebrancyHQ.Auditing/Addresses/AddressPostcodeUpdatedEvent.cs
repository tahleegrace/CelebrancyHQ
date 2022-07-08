namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// An event that occurs when the postcode of an address is updated.
    /// </summary>
    public class AddressPostcodeUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Postcode";

        /// <summary>
        /// Creates a new instance of AddressPostcodeUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old postcode.</param>
        /// <param name="newValue">The new postcode.</param>
        public AddressPostcodeUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}