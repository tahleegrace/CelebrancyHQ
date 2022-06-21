using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Organisations
{
    /// <summary>
    /// An event that occurs when an organisation is created.
    /// </summary>
    public class OrganisationCreatedEvent : EntityCreatedEvent<Organisation>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Organisations";

        /// <summary>
        /// Creates a new instance of OrganisationCreatedEvent.
        /// </summary>
        /// <param name="value">The new organisation.</param>
        public OrganisationCreatedEvent(Organisation value)
            : base(null, value)
        {
        }
    }
}