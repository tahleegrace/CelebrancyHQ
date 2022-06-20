using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when a person is deleted.
    /// </summary>
    public class PersonDeletedEvent : EntityDeletedEvent<Person>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Persons";

        /// <summary>
        /// Creates a new instance of PersonDeletedEvent.
        /// </summary>
        /// <param name="value">The new person.</param>
        public PersonDeletedEvent(Person value)
            : base(null, value)
        {
        }
    }
}