namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when the email address of a person is updated.
    /// </summary>
    public class PersonEmailAddressUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "EmailAddress";

        /// <summary>
        /// Creates a new instance of PersonEmailAddressUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old email address.</param>
        /// <param name="newValue">The new email address.</param>
        public PersonEmailAddressUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}