namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when the description of a person phone number is updated.
    /// </summary>
    public class PersonPhoneNumberDescriptionUpdatedEvent : SubFieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "PhoneNumbers";

        /// <summary>
        /// Gets the sub field name.
        /// </summary>
        public override string SubFieldName { get; } = "Description";

        /// <summary>
        /// Creates a new instance of PersonPhoneNumberDescriptionUpdatedEvent.
        /// </summary>
        /// <param name="id">The ID of the person phone number.</param>
        /// <param name="oldValue">The old description.</param>
        /// <param name="newValue">The new description.</param>
        public PersonPhoneNumberDescriptionUpdatedEvent(int id, string? oldValue, string? newValue)
            : base(id, oldValue, newValue)
        {
        }
    }
}