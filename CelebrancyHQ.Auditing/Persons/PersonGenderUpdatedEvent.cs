namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when the gender of a person is updated.
    /// </summary>
    public class PersonGenderUpdatedEvent : FieldUpdatedEvent<string?>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Gender";

        /// <summary>
        /// Creates a new instance of PersonGenderUpdatedEvent.
        /// </summary>
        /// <param name="oldValue">The old gender.</param>
        /// <param name="newValue">The new gender.</param>
        public PersonGenderUpdatedEvent(string? oldValue, string? newValue)
            : base(oldValue, newValue)
        {
        }
    }
}