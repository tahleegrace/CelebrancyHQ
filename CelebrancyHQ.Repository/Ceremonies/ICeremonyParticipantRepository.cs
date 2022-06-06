namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony participant repository.
    /// </summary>
    public interface ICeremonyParticipantRepository
    {
        /// <summary>
        /// Gets whether the specified person is a participant in the specified ceremony.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>Whether the specified person is a participant in the specified ceremony.</returns>
        Task<bool> PersonIsCeremonyParticipant(int personId, int ceremonyId);
    }
}