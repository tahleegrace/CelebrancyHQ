using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Auditing
{
    /// <summary>
    /// A service that generates audit logs for an entity.
    /// </summary>
    /// <typeparam name="EntityType">The type of entity to generate audit logs for.</typeparam>
    public interface IAuditingService<EntityType> where EntityType : BaseEntity
    {
        /// <summary>
        /// Generates audit logs for the changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.
        /// </summary>
        /// <param name="oldEntity">The old entity.</param>
        /// <param name="newEntity">The new entity.</param>
        /// <returns>A list of audit logs for changes between <paramref name="oldEntity"/> and <paramref name="newEntity"/>.</returns>
        List<AuditEvent> GenerateAuditEvents(EntityType oldEntity, EntityType newEntity);

        /// <summary>
        /// Saves a list of audit events.
        /// </summary>
        /// <param name="entity">The entity that was changed.</param>
        /// <param name="personId">The ID of the person who made the changes.</param>
        /// <param name="auditEvents">The audit events to save.</param>
        Task SaveAuditEvents(EntityType entity, int personId, List<AuditEvent> auditEvents);
    }
}