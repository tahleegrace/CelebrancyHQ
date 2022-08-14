namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// An event that occurs when the street address of an address is updated.
    /// </summary>
    public class AddressStreetAddressUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the ID of the address.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "StreetAddress";

        /// <summary>
        /// Creates a new instance of AddressStreetAddressUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the address.</param>
        /// <param name="oldValue">The old street address.</param>
        /// <param name="newValue">The new street address.</param>
        public AddressStreetAddressUpdatedEvent(int id, string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
            this.Id = id;
        }
    }
}