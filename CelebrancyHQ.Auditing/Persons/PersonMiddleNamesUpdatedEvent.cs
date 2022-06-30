namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when the middle names of a person are updated.
    /// </summary>
    public class PersonMiddleNamesUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "MiddleNames";

        /// <summary>
        /// Creates a new instance of PersonMiddleNamesUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old middle names.</param>
        /// <param name="newValue">The new middle names.</param>
        public PersonMiddleNamesUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}