using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functions for managing ceremony participants.
    /// </summary>
    public interface ICeremonyParticipantService
    {
        /// <summary>
        /// Creates a new ceremony participant.
        /// </summary>
        /// <param name="request">The participant.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created participant.</returns>
        Task<CeremonyParticipantDTO> Create(CreateCeremonyParticipantRequest request, int ceremonyId, int currentUserId);

        /// <summary>
        /// Deletes the specified ceremony participant.
        /// </summary>
        /// <param name="participantId">The ID of the participant.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task Delete(int participantId, int currentUserId);
    }
}