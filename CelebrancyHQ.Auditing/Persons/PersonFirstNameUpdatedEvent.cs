namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when the first name of a person is updated.
    /// </summary>
    public class PersonFirstNameUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "FirstName";

        /// <summary>
        /// Creates a new instance of PersonFirstNameUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old first name.</param>
        /// <param name="newValue">The new first name.</param>
        public PersonFirstNameUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}