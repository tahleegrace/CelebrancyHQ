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

        /// <summary>
        /// Finds the ceremony type forms that can be offered by the current user's organisation.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The ceremony type forms that can be offered by the current user's organisation for the specified ceremony type.</returns>
        Task<List<CeremonyTypeFormDTO>> GetAllCeremonyTypeForms(int ceremonyTypeId, int currentUserId);
    }
}