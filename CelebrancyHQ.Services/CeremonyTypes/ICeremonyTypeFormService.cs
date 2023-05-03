using CelebrancyHQ.Models.DTOs.CeremonyTypes;

namespace CelebrancyHQ.Services.CeremonyTypes
{
    /// <summary>
    /// A ceremony type form service.
    /// </summary>
    public interface ICeremonyTypeFormService
    {
        /// <summary>
        /// Gets the ceremony type form with the specified ID.
        /// </summary>
        /// <param name="formId">The ID of the form.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The ceremony type form with the specified ID.</returns>
        Task<CeremonyTypeFormDTO> GetCeremonyTypeForm(int formId, int currentUserId);
    }
}