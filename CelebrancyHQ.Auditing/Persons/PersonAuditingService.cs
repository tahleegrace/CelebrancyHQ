using Newtonsoft.Json;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;
using CelebrancyHQ.Repository.Persons;

namespace CelebrancyHQ.Auditing.Persons
{
    /// <summary>
    /// The person auditing service.
    /// </summary>
    public class PersonAuditingService : IPersonAuditingService
    {
        private readonly IPersonAuditLogRepository _personAuditLogRepository;

        /// <summary>
        /// Creates a new instance of PersonAuditingService.
        /// </summary>
        /// <param name="personAuditLogRepository">The person audit logs repository.</param>
        public PersonAuditingService(IPersonAuditLogRepository personAuditLogRepository)
        {
            this._personAuditLogRepository = personAuditLogRepository;
        }

        /// <summary>
        /// Generates audit logs for the changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.
        /// </summary>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>A list of audit logs for changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.</returns>
        public List<AuditEvent> GenerateAuditEvents(Person? oldEntity, Person? newEntity)
        {
            List<AuditEvent> auditEvents = new List<AuditEvent>();

            if (oldEntity == null && newEntity != null)
            {
                auditEvents.Add(new PersonCreatedEvent(newEntity));
            }
            else if (oldEntity != null && newEntity == null)
            {
                auditEvents.Add(new PersonDeletedEvent(oldEntity));
            }
            else if (oldEntity != null && newEntity != null)
            {
                if (oldEntity.FirstName != newEntity.FirstName)
                {
                    auditEvents.Add(new PersonFirstNameUpdatedEvent(oldEntity.FirstName, newEntity.FirstName));
                }

                if (oldEntity.MiddleNames != newEntity.MiddleNames)
                {
                    auditEvents.Add(new PersonMiddleNamesUpdatedEvent(oldEntity.MiddleNames, newEntity.MiddleNames));
                }

                if (oldEntity.LastName != newEntity.LastName)
                {
                    auditEvents.Add(new PersonLastNameUpdatedEvent(oldEntity.LastName, newEntity.LastName));
                }

                if (oldEntity.PreferredName != newEntity.PreferredName)
                {
                    auditEvents.Add(new PersonPreferredNameUpdatedEvent(oldEntity.PreferredName, newEntity.PreferredName));
                }

                if (oldEntity.Title != newEntity.Title)
                {
                    auditEvents.Add(new PersonTitleUpdatedEvent(oldEntity.Title, newEntity.Title));
                }

                if (oldEntity.Gender != newEntity.Gender)
                {
                    auditEvents.Add(new PersonGenderUpdatedEvent(oldEntity.Gender, newEntity.Gender));
                }

                if (oldEntity.EmailAddress != newEntity.EmailAddress)
                {
                    auditEvents.Add(new PersonEmailAddressUpdatedEvent(oldEntity.EmailAddress, newEntity.EmailAddress));
                }
            }

            return auditEvents;
        }

        /// <summary>
        /// Saves a list of audit events.
        /// </summary>
        /// <param name="entity">The entity that was changed.</param>
        /// <param name="personId">The ID of the person who made the changes.</param>
        /// <param name="auditEvents">The audit events to save.</param>
        public async Task SaveAuditEvents(Person entity, int personId, List<AuditEvent> auditEvents)
        {
            if (auditEvents == null || auditEvents.Count == 0)
            {
                return;
            }

            PersonAuditLog auditLog = new PersonAuditLog()
            {
                PersonId = entity.Id,
                UpdatedById = personId,
                Event = JsonConvert.SerializeObject(auditEvents),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            await this._personAuditLogRepository.CreateAuditLog(auditLog);
        }
    }
}