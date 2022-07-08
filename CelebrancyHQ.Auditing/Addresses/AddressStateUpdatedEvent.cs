namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// An event that occurs when the state of an address is updated.
    /// </summary>
    public class AddressStateUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "State";

        /// <summary>
        /// Creates a new instance of AddressStateUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old state.</param>
        /// <param name="newValue">The new state.</param>
        public AddressStateUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}