namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when the title of a person is updated.
    /// </summary>
    public class PersonTitleUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Title";

        /// <summary>
        /// Creates a new instance of PersonTitleUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old title.</param>
        /// <param name="newValue">The new title.</param>
        public PersonTitleUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}