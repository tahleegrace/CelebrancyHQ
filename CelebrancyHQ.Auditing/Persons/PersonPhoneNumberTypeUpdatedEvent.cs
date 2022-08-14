namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when the type of a person phone number is updated.
    /// </summary>
    public class PersonPhoneNumberTypeUpdatedEvent : SubFieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "PhoneNumbers";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "Type";

        /// <summary>
        /// Creates a new instance of PersonPhoneNumberTypeUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the person phone number.</param>
        /// <param name="oldValue">The old type.</param>
        /// <param name="newValue">The new type.</param>
        public PersonPhoneNumberTypeUpdatedEvent(int id, string? oldValue, string? newValue)
            : base(id, oldValue, newValue)
        {
        }
    }
}