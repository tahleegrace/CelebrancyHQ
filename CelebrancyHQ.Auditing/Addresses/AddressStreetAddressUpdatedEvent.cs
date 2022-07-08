namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// An event that occurs when the street address of an address is updated.
    /// </summary>
    public class AddressStreetAddressUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "StreetAddress";

        /// <summary>
        /// Creates a new instance of AddressStreetAddressUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old street address.</param>
        /// <param name="newValue">The new street address.</param>
        public AddressStreetAddressUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}