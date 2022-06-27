using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Auditing.Organisations
{
    /// <summary>
    /// An event that occurs when an organisation is deleted.
    /// </summary>
    public class OrganisationDeletedEvent : EntityDeletedEvent<Organisation>
    {
        /// <summary>
        /// Gets the field name.
        /// </summary>
        public override string FieldName { get; } = "Organisations";

        /// <summary>
        /// Creates a new instance of OrganisationDeletedEvent.
        /// </summary>
        /// <param name="value">The organisation that was deleted.</param>
        public OrganisationDeletedEvent(Organisation value)
            : base(null, value)
        {
        }
    }
}