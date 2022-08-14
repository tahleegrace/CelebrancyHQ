namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// An event that occurs when the postcode of an address is updated.
    /// </summary>
    public class AddressPostcodeUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the ID of the address.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Postcode";

        /// <summary>
        /// Creates a new instance of AddressPostcodeUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the address.</param>
        /// <param name="oldValue">The old postcode.</param>
        /// <param name="newValue">The new postcode.</param>
        public AddressPostcodeUpdatedEvent(int id, string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
            this.Id = id;
        }
    }
}