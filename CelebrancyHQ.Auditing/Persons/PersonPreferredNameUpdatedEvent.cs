namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when the preferred name of a person is updated.
    /// </summary>
    public class PersonPreferredNameUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "PreferredName";

        /// <summary>
        /// Creates a new instance of PersonPreferredNameUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old preferred name.</param>
        /// <param name="newValue">The new preferred name.</param>
        public PersonPreferredNameUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}