using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony meeting repository.
    /// </summary>
    public class CeremonyMeetingRepository : ICeremonyMeetingRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyMeetingRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyMeetingRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the ceremony meeting with the specified ID.
        /// </summary>
        /// <param name="ceremonyMeetingId">The ID of the ceremony meeting.</param>
        /// <returns>The ceremony meeting with the specified ID.</returns>
        public async Task<CeremonyMeeting?> FindById(int ceremonyMeetingId)
        {
            return await this._context.CeremonyMeetings.Include(cm => cm.CeremonyTypeMeeting)
                                                       .Where(cm => cm.Id == ceremonyMeetingId && !cm.Deleted)
                                                       .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the meetings for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The meetings for the specified ceremony.</returns>
        public async Task<List<CeremonyMeeting>> GetCeremonyMeetings(int ceremonyId)
        {
            return await this._context.CeremonyMeetings.Include(cm => cm.CeremonyTypeMeeting)
                                                       .Where(cm => cm.CeremonyId == ceremonyId && !cm.Deleted)
                                                       .ToListAsync();
        }

        /// <summary>
        /// Creates a new ceremony meeting.
        /// </summary>
        /// <param name="meeting">The meeting.</param>
        /// <returns>The newly created ceremony meeting.</returns>
        public async Task<CeremonyMeeting> Create(CeremonyMeeting meeting)
        {
            meeting.Created = DateTime.UtcNow;
            meeting.Updated = DateTime.UtcNow;

            this._context.CeremonyMeetings.Add(meeting);

            await this._context.SaveChangesAsync();

            var newMeeting = await FindById(meeting.Id);
            return newMeeting;
        }
    }
}