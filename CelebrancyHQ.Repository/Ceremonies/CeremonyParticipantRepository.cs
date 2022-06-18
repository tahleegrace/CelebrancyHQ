using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony participant repository.
    /// </summary>
    public class CeremonyParticipantRepository : ICeremonyParticipantRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyParticipantRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyParticipantRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the ceremony participant with the specified ID.
        /// </summary>
        /// <param name="ceremonyParticipantId">The ID of the ceremony participant.</param>
        /// <returns>The ceremony participant with the specified ID.</returns>
        public async Task<CeremonyParticipant?> FindById(int ceremonyParticipantId)
        {
            return await this._context.CeremonyParticipants.Include(cp => cp.CeremonyTypeParticipant)
                                                           .Where(cp => cp.Id == ceremonyParticipantId && !cp.Deleted)
                                                           .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets whether the specified person is a participant in the specified ceremony.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>Whether the specified person is a participant in the specified ceremony.</returns>
        public async Task<bool> PersonIsCeremonyParticipant(int personId, int ceremonyId)
        {
            return await this._context.CeremonyParticipants.Where(cp => cp.PersonId == personId && cp.CeremonyId == ceremonyId && !cp.Deleted).AnyAsync();
        }

        /// <summary>
        /// Gets whether the specified person is a participant of the specified type in the specified ceremony.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="code">The ceremony type participant code.</param>
        /// <returns>Whether the specified person is a participant of the specified type in the specified ceremony.</returns>
        public async Task<bool> PersonIsCeremonyParticipant(int personId, int ceremonyId, string code)
        {
            return await this._context.CeremonyParticipants.Include(cp => cp.CeremonyTypeParticipant)
                                                           .Where(cp => cp.PersonId == personId && cp.CeremonyId == ceremonyId
                                                                     && cp.CeremonyTypeParticipant.Code == code && !cp.Deleted)
                                                           .AnyAsync();
        }

        /// <summary>
        /// Gets the participants for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The participants for the specified ceremony.</returns>
        public async Task<List<CeremonyParticipant>> GetCeremonyParticipants(int ceremonyId)
        {
            return await this._context.CeremonyParticipants.Include(cp => cp.Person)
                                                           .Include(cp => cp.Person.Organisation)
                                                           .Include(cp => cp.CeremonyTypeParticipant)
                                                           .Where(cp => cp.CeremonyId == ceremonyId && !cp.Deleted)
                                                           .ToListAsync();
                
        }

        /// <summary>
        /// Creates a new ceremony participant.
        /// </summary>
        /// <param name="participant">The participant.</param>
        /// <returns>The newly created ceremony participant.</returns>
        public async Task<CeremonyParticipant> Create(CeremonyParticipant participant)
        {
            participant.Created = DateTime.UtcNow;
            participant.Updated = DateTime.UtcNow;

            this._context.CeremonyParticipants.Add(participant);

            await this._context.SaveChangesAsync();

            var newParticipant = await FindById(participant.Id);
            return newParticipant;
        }
    }
}