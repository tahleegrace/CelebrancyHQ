namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// An event that occurs when the suburb of an address is updated.
    /// </summary>
    public class AddressSuburbUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Suburb";

        /// <summary>
        /// Creates a new instance of AddressSuburbUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old suburb.</param>
        /// <param name="newValue">The new suburb.</param>
        public AddressSuburbUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}