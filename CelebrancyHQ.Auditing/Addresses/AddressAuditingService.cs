using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Auditing.Addresses
{
    /// <summary>
    /// The address auditing service.
    /// </summary>
    public abstract class AddressAuditingService
    {
        /// <summary>
        /// Generates audit logs for the changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.
        /// </summary>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>A list of audit logs for changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.</returns>
        public List<AuditEvent> GenerateAuditEvents(Address? oldEntity, Address? newEntity)
        {
            List<AuditEvent> auditEvents = new List<AuditEvent>();

            if (oldEntity == null && newEntity != null)
            {
                auditEvents.Add(new AddressCreatedEvent(newEntity));
            }
            else if (oldEntity != null && newEntity != null)
            {
                if (oldEntity.StreetAddress != newEntity.StreetAddress)
                {
                    auditEvents.Add(new AddressStreetAddressUpdatedEvent(oldEntity.StreetAddress, newEntity.StreetAddress));
                }

                if (oldEntity.Suburb != newEntity.Suburb)
                {
                    auditEvents.Add(new AddressSuburbUpdatedEvent(oldEntity.Suburb, newEntity.Suburb));
                }

                if (oldEntity.State != newEntity.State)
                {
                    auditEvents.Add(new AddressStateUpdatedEvent(oldEntity.State, newEntity.State));
                }

                if (oldEntity.Postcode != newEntity.Postcode)
                {
                    auditEvents.Add(new AddressPostcodeUpdatedEvent(oldEntity.Postcode, newEntity.Postcode));
                }

                if (oldEntity.Country != newEntity.Country)
                {
                    auditEvents.Add(new AddressCountryUpdatedEvent(oldEntity.Country, newEntity.Country));
                }
            }

            return auditEvents;
        }
    }
}