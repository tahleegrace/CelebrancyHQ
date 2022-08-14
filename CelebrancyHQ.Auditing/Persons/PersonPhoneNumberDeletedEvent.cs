using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// An event that occurs when a person phone number is deleted.
    /// </summary>
    public class PersonPhoneNumberDeletedEvent : EntityDeletedEvent<PersonPhoneNumber>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "PhoneNumbers";

        /// <summary>
        /// Creates a new instance of PersonPhoneNumberDeletedEvent.
        /// </summary>
        /// <param name="value">The phone number that was deleted.</param>
        public PersonPhoneNumberDeletedEvent(PersonPhoneNumber value)
            : base(null, value)
        {
        }
    }
}