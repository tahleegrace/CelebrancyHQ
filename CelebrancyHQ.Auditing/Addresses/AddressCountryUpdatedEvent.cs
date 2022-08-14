namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// An event that occurs when the country of an address is updated.
    /// </summary>
    public class AddressCountryUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the ID of the address.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Country";

        /// <summary>
        /// Creates a new instance of AddressCountryUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the address.</param>
        /// <param name="oldValue">The old country.</param>
        /// <param name="newValue">The new country.</param>
        public AddressCountryUpdatedEvent(int id, string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
            this.Id = id;
        }
    }
}