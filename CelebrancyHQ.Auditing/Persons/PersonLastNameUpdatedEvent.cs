namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when the last name of a person is updated.
    /// </summary>
    public class PersonLastNameUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "LastName";

        /// <summary>
        /// Creates a new instance of PersonLastNameUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old last name.</param>
        /// <param name="newValue">The new last name.</param>
        public PersonLastNameUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}