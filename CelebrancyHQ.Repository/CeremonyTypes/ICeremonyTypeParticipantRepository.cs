using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.CeremonyTypes
{
    /// <summary>
    /// A ceremony type participant repository.
    /// </summary>
    public interface ICeremonyTypeParticipantRepository
    {
        /// <summary>
        /// Finds the ceremony type participants for the specified ceremony type.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="codeToExclude">The code of ceremony type participants to exclude.</param>
        /// <returns>The ceremony type participants for the specified ceremony type.</returns>
        Task<List<CeremonyTypeParticipant>> FindByCeremonyTypeId(int ceremonyTypeId, string? codeToExclude);

        /// <summary>
        /// Finds the IDs of the ceremony type participants with the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>The IDs of the ceremony type participants with the specified code.</returns>
        Task<List<int>> FindIdsByCode(string code);

        /// <summary>
        /// Finds the ceremony type participant for the specified ceremony type with the specified code.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="code">The code of the ceremony type participant.</param>
        /// <returns>The ceremony type participant for the specified ceremony type with the specified code.</returns>
        Task<CeremonyTypeParticipant?> FindByCode(int ceremonyTypeId, string code);
    }
}