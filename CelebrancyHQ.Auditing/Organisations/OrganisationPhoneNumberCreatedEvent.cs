using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Organisations
{
    /// <summary>
    /// An event that occurs when an organisation phone number is created.
    /// </summary>
    public class OrganisationPhoneNumberCreatedEvent : EntityCreatedEvent<OrganisationPhoneNumber>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "PhoneNumbers";

        /// <summary>
        /// Creates a new instance of OrganisationPhoneNumberCreatedEvent.
        /// </summary>
        /// <param name="value">The new phone number.</param>
        public OrganisationPhoneNumberCreatedEvent(OrganisationPhoneNumber value)
            : base(null, value)
        {
        }
    }
}