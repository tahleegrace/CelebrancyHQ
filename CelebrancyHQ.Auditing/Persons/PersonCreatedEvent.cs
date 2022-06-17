using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when a person is created.
    /// </summary>
    public class PersonCreatedEvent : EntityCreatedEvent<Person>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Persons";

        /// <summary>
        /// Creates a new instance of PersonCreatedEvent.
        /// </summary>
        /// <param name="value">The new person.</param>
        public PersonCreatedEvent(Person value)
            : base(null, value)
        {
        }
    }
}