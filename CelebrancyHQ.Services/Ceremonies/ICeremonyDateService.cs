using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functionality for managing ceremony dates.
    /// </summary>
    public interface ICeremonyDateService
    {
        /// <summary>
        /// Gets the dates for the ceremony with the specified ID.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The dates for the ceremony with the specified ID.</returns>
        Task<List<CeremonyDateDTO>> GetDates(int ceremonyId, int currentUserId);

        /// <summary>
        /// Creates a new date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created date.</returns>
        Task<CeremonyDateDTO> Create(CreateCeremonyDateRequest date, int ceremonyId, int currentUserId);

        /// <summary>
        /// Updates the specified date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly updated date or null if the date was deleted.</returns>
        Task<CeremonyDateDTO?> Update(UpdateCeremonyDateRequest date, int ceremonyId, int currentUserId);
    }
}