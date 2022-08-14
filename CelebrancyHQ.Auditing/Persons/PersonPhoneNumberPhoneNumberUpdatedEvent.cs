namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when the phone number of a person phone number is updated.
    /// </summary>
    public class PersonPhoneNumberPhoneNumberUpdatedEvent : SubFieldUpdatedEvent<string>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "PhoneNumbers";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "PhoneNumber";

        /// <summary>
        /// Creates a new instance of PersonPhoneNumberPhoneNumberUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the person phone number.</param>
        /// <param name="oldValue">The old phone number.</param>
        /// <param name="newValue">The new phone number.</param>
        public PersonPhoneNumberPhoneNumberUpdatedEvent(int id, string oldValue, string newValue)
            : base(id, oldValue, newValue)
        {
        }
    }
}