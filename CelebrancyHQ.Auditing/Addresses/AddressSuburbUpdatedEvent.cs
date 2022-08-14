namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// An event that occurs when the suburb of an address is updated.
    /// </summary>
    public class AddressSuburbUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the ID of the address.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Suburb";

        /// <summary>
        /// Creates a new instance of AddressSuburbUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the address.</param>
        /// <param name="oldValue">The old suburb.</param>
        /// <param name="newValue">The new suburb.</param>
        public AddressSuburbUpdatedEvent(int id, string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
            this.Id = id;
        }
    }
}