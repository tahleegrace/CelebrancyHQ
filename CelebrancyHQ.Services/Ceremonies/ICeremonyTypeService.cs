using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functions for managing the types of ceremonies that can be offered.
    /// </summary>
    public interface ICeremonyTypeService
    {
        /// <summary>
        /// Gets the types of ceremonies the specified user can offer.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The types of ceremonies the user can offer.</returns>
        Task<List<CeremonyTypeDTO>> GetCeremonyTypes(int userId);
    }
}