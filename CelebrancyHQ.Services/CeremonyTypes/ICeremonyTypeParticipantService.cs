using CelebrancyHQ.Models.DTOs.CeremonyTypes;

namespace CelebrancyHQ.Services.CeremonyTypes
{
    /// <summary>
    /// A ceremony type participant service.
    /// </summary>
    public interface ICeremonyTypeParticipantService
    {
        /// <summary>
        /// Gets the ceremony type participants for the specified ceremony type.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="codeToExclude">The code of ceremony type participants to exclude.</param>
        /// <returns>The ceremony type participants for the specified ceremony type.</returns>
        Task<List<CeremonyTypeParticipantDTO>> GetCeremonyTypeParticipants(int ceremonyTypeId, string? codeToExclude);
    }
}