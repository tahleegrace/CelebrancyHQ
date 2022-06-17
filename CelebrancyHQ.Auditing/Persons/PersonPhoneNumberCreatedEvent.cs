using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when a person phone number is created.
    /// </summary>
    public class PersonPhoneNumberCreatedEvent : EntityCreatedEvent<PersonPhoneNumber>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "PhoneNumbers";

        /// <summary>
        /// Creates a new instance of PersonPhoneNumberCreatedEvent.
        /// </summary>
        /// <param name="value">The new phone number.</param>
        public PersonPhoneNumberCreatedEvent(PersonPhoneNumber value)
            : base(null, value)
        {
        }
    }
}