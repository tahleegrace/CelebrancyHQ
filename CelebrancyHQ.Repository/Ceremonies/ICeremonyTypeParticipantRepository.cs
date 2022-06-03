namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony type participant repository.
    /// </summary>
    public interface ICeremonyTypeParticipantRepository
    {
        /// <summary>
        /// Finds the IDs of the ceremony type participants with the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>The IDs of the ceremony type participants with the specified code.</returns>
        Task<List<int>> FindIdsByCode(string code);
    }
}