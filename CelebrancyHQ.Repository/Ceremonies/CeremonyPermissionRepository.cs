using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony permissions repository.
    /// </summary>
    public class CeremonyPermissionRepository : ICeremonyPermissionRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyPermissionRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyPermissionRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the ceremony permissions for the specified ceremony and person.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <returns>The ceremony permissions matching the specified criteria.</returns>
        public async Task<List<CeremonyPermission>> GetCeremonyPermissionsForPerson(int ceremonyId, int personId)
        {
            var ceremonyTypeParticipantIds = await this._context.CeremonyParticipants.Where(cp => cp.CeremonyId == ceremonyId && cp.PersonId == personId && !cp.Deleted)
                                                                                     .Select(cp => cp.CeremonyTypeParticipantId)
                                                                                     .ToListAsync();

            if (ceremonyTypeParticipantIds.Count == 0)
            {
                return new List<CeremonyPermission>();
            }

            return await this._context.CeremonyPermissions.Where(cp => cp.CeremonyId == ceremonyId
                                                                    && ceremonyTypeParticipantIds.Contains(cp.CeremonyTypeParticipantId)
                                                                    && !cp.Deleted)
                                                          .ToListAsync();
        }

        /// <summary>
        /// Gets the ceremony permissions for the specified ceremony, person and field.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="field">The name of the field.</param>
        /// <returns>The ceremony permissions matching the specified criteria.</returns>
        public async Task<List<CeremonyPermission>> GetCeremonyPermissionsForPerson(int ceremonyId, int personId, string field)
        {
            var ceremonyTypeParticipantIds = await this._context.CeremonyParticipants.Where(cp => cp.CeremonyId == ceremonyId && cp.PersonId == personId && !cp.Deleted)
                                                                                     .Select(cp => cp.CeremonyTypeParticipantId)
                                                                                     .ToListAsync();

            if (ceremonyTypeParticipantIds.Count == 0)
            {
                return new List<CeremonyPermission>();
            }

            return await this._context.CeremonyPermissions.Where(cp => cp.CeremonyId == ceremonyId
                                                                    && ceremonyTypeParticipantIds.Contains(cp.CeremonyTypeParticipantId) && cp.Field == field 
                                                                    && !cp.Deleted)
                                                          .ToListAsync();
        }
    }
}