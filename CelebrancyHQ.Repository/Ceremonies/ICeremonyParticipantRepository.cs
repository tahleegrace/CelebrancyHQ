using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony participant repository.
    /// </summary>
    public interface ICeremonyParticipantRepository
    {
        /// <summary>
        /// Gets the ceremony participant with the specified ID.
        /// </summary>
        /// <param name="ceremonyParticipantId">The ID of the ceremony participant.</param>
        /// <returns>The ceremony participant with the specified ID.</returns>
        Task<CeremonyParticipant?> FindById(int ceremonyParticipantId);

        /// <summary>
        /// Gets whether the specified person is a participant in the specified ceremony.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>Whether the specified person is a participant in the specified ceremony.</returns>
        Task<bool> PersonIsCeremonyParticipant(int personId, int ceremonyId);

        /// <summary>
        /// Gets whether the specified person is a participant of the specified type in the specified ceremony.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="code">The ceremony type participant code.</param>
        /// <returns>Whether the specified person is a participant of the specified type in the specified ceremony.</returns>
        Task<bool> PersonIsCeremonyParticipant(int personId, int ceremonyId, string code);

        /// <summary>
        /// Gets whether the specified person is a participant in any ceremonies other than the specified ceremony.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="ceremonyToExcludeId">The ID of the ceremony.</param>
        /// <returns>Whether the specified person is a participant in any ceremonies other than the specified ceremony.</returns>
        Task<bool> PersonIsParticipantInOtherCeremonies(int personId, int ceremonyToExcludeId);

        /// <summary>
        /// Gets the participants for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The participants for the specified ceremony.</returns>
        Task<List<CeremonyParticipant>> GetCeremonyParticipants(int ceremonyId);

        /// <summary>
        /// Creates a new ceremony participant.
        /// </summary>
        /// <param name="participant">The participant.</param>
        /// <returns>The newly created ceremony participant.</returns>
        Task<CeremonyParticipant> Create(CeremonyParticipant participant);

        /// <summary>
        /// Deletes the specified participant.
        /// </summary>
        /// <param name="id">The ID of the participant to delete.</param>
        Task Delete(int id);
    }
}