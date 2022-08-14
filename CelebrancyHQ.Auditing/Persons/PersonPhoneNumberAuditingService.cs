using Newtonsoft.Json;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;
using CelebrancyHQ.Repository.Persons;

namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// The person phone number auditing service.
    /// </summary>
    public class PersonPhoneNumberAuditingService : IPersonPhoneNumberAuditingService
    {
        private readonly IPersonAuditLogRepository _personAuditLogRepository;

        /// <summary>
        /// Creates a new instance of PersonPhoneNumberAuditingService.
        /// </summary>
        /// <param name="personAuditLogRepository">The person audit logs repository.</param>
        public PersonPhoneNumberAuditingService(IPersonAuditLogRepository personAuditLogRepository)
        {
            this._personAuditLogRepository = personAuditLogRepository;
        }

        /// <summary>
        /// Generates audit logs for the changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.
        /// </summary>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>A list of audit logs for changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.</returns>
        public List<AuditEvent> GenerateAuditEvents(PersonPhoneNumber? oldEntity, PersonPhoneNumber? newEntity)
        {
            List<AuditEvent> auditEvents = new List<AuditEvent>();

            if (oldEntity == null && newEntity != null)
            {
                auditEvents.Add(new PersonPhoneNumberCreatedEvent(newEntity));
            }
            else if (oldEntity != null && newEntity == null)
            {
                auditEvents.Add(new PersonPhoneNumberDeletedEvent(oldEntity));
            }
            else if (oldEntity != null && newEntity != null)
            {
                if (oldEntity.Type != newEntity.Type)
                {
                    auditEvents.Add(new PersonPhoneNumberTypeUpdatedEvent(newEntity.Id, oldEntity.Type, newEntity.Type));
                }

                if (oldEntity.Description != newEntity.Description)
                {
                    auditEvents.Add(new PersonPhoneNumberDescriptionUpdatedEvent(newEntity.Id, oldEntity.Description, newEntity.Description));
                }

                if (oldEntity.PhoneNumber != newEntity.PhoneNumber)
                {
                    auditEvents.Add(new PersonPhoneNumberPhoneNumberUpdatedEvent(newEntity.Id, oldEntity.PhoneNumber, newEntity.PhoneNumber));
                }
            }

            return auditEvents;
        }

        /// <summary>
        /// Saves a list of audit events.
        /// </summary>
        /// <param name="entity">The entity that was changed.</param>
        /// <param name="parentEntity">The parent entity.</param>
        /// <param name="personId">The ID of the person who made the changes.</param>
        /// <param name="auditEvents">The audit events to save.</param>
        public async Task SaveAuditEvents(PersonPhoneNumber entity, Person parentEntity, int personId, List<AuditEvent> auditEvents)
        {
            if (auditEvents == null || auditEvents.Count == 0)
            {
                return;
            }

            PersonAuditLog auditLog = new PersonAuditLog()
            {
                PersonId = parentEntity.Id,
                UpdatedById = personId,
                Event = JsonConvert.SerializeObject(auditEvents),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await this._personAuditLogRepository.CreateAuditLog(auditLog);
        }
    }
}