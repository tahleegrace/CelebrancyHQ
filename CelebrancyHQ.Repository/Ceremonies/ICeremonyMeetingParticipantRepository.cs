using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony meeting participants repository.
    /// </summary>
    public interface ICeremonyMeetingParticipantRepository
    {
        /// <summary>
        /// Gets the ceremony meeting participant with the specified ID.
        /// </summary>
        /// <param name="participantId">The ID of the ceremony meeting participant.</param>
        /// <returns>The ceremony meeting participant with the specified ID.</returns>
        Task<CeremonyMeetingParticipant?> FindById(int participantId);

        /// <summary>
        /// Gets the participants for the specified meeting.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <returns>The participants for the specified meeting.</returns>
        Task<List<CeremonyMeetingParticipant>> GetParticipantsForMeeting(int meetingId);

        /// <summary>
        /// Gets whether a ceremony meeting participant exists in the specified meeting with the specified person ID.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="personId">The ID of the person.</param>
        /// <returns>Whether a ceremony meeting participant exists in the specified meeting with the specified person ID.</returns>
        Task<bool> ParticipantExistsWithPersonId(int meetingId, int personId);

        /// <summary>
        /// Creates a new ceremony meeting participant.
        /// </summary>
        /// <param name="participant">The participant.</param>
        /// <returns>The newly created ceremony meeting participant.
        /// </returns>
        Task<CeremonyMeetingParticipant> Create(CeremonyMeetingParticipant participant);
    }
}