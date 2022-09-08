using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony meeting participants repository.
    /// </summary>
    public class CeremonyMeetingParticipantRepository : ICeremonyMeetingParticipantRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyMeetingParticipantRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyMeetingParticipantRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the ceremony meeting participant with the specified ID.
        /// </summary>
        /// <param name="participantId">The ID of the ceremony meeting participant.</param>
        /// <returns>The ceremony meeting participant with the specified ID.</returns>
        public async Task<CeremonyMeetingParticipant?> FindById(int participantId)
        {
            return await this._context.CeremonyMeetingParticipants.Include(cmp => cmp.Person)
                                                                  .Where(cmp => cmp.Id == participantId && !cmp.Deleted)
                                                                  .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets the participants for the specified meeting.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <returns>The participants for the specified meeting.</returns>
        public async Task<List<CeremonyMeetingParticipant>> GetParticipantsForMeeting(int meetingId)
        {
            return await this._context.CeremonyMeetingParticipants.Include(cmp => cmp.Person)
                                                                  .Where(cmp => cmp.CeremonyMeetingId == meetingId && !cmp.Deleted)
                                                                  .ToListAsync();
        }

        /// <summary>
        /// Gets whether a ceremony meeting participant exists in the specified meeting with the specified person ID.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <returns>Whether a ceremony meeting participant exists in the specified meeting with the specified person ID.</returns>
        public async Task<bool> ParticipantExistsWithPersonId(int meetingId, int personId)
        {
            return await this._context.CeremonyMeetingParticipants.Where(cmp => cmp.CeremonyMeetingId == meetingId && cmp.PersonId == personId && !cmp.Deleted).AnyAsync();
        }

        /// <summary>
        /// Creates a new ceremony meeting participant.
        /// </summary>
        /// <param name="participant">The participant.</param>
        /// <returns>The newly created ceremony meeting participant.
        /// </returns>
        public async Task<CeremonyMeetingParticipant> Create(CeremonyMeetingParticipant participant)
        {
            participant.Created = DateTime.UtcNow;
            participant.Updated = DateTime.UtcNow;

            this._context.CeremonyMeetingParticipants.Add(participant);

            await this._context.SaveChangesAsync();

            var newParticipant = await FindById(participant.Id);
            return newParticipant;
        }
    }
}