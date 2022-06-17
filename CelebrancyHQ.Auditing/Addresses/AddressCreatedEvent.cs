using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// An event that occurs when an address is created.
    /// </summary>
    public class AddressCreatedEvent : EntityCreatedEvent<Address>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Address";

        /// <summary>
        /// Creates a new instance of AddressCreatedEvent.
        /// </summary>
        /// <param name="value">The new address.</param>
        public AddressCreatedEvent(Address value)
            : base(null, value)
        {
        }
    }
}