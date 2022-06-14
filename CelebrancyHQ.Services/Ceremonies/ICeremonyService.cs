using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functions for managing ceremonies.
    /// </summary>
    public interface ICeremonyService
    {
        /// <summary>
        /// Gets all the ceremonies where the specified user has the specified participant type between the specified dates.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="participantTypeCode">The participant type.</param>
        /// <param name="from">The from date.</param>
        /// <param name="to">The to date.</param>
        /// <returns>The ceremonies matching the specified criteria.</returns>
        Task<List<CeremonySummaryDTO>> GetAll(int userId, string? participantTypeCode, DateTime? from, DateTime? to);

        /// <summary>
        /// Gets the key details for the ceremony with the specified ID.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The key details for the ceremony with the specified ID.</returns>
        Task<CeremonyKeyDetailsDTO> GetCeremonyKeyDetails(int ceremonyId, int currentUserId);

        /// <summary>
        /// Gets the dates for the ceremony with the specified ID.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The dates for the ceremony with the specified ID.</returns>
        Task<List<CeremonyDateDTO>> GetCeremonyDates(int ceremonyId, int currentUserId);

        /// <summary>
        /// Updates the details of the specified ceremony.
        /// </summary>
        /// <param name="ceremony">The ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task Update(UpdateCeremonyRequest ceremony, int currentUserId);

        /// <summary>
        /// Creates a new date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created date.</returns>
        Task<CeremonyDateDTO> CreateDate(CreateCeremonyDateRequest date, int ceremonyId, int currentUserId);

        /// <summary>
        /// Updates the specified date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created date or null if the date was deleted.</returns>
        Task<CeremonyDateDTO?> UpdateDate(UpdateCeremonyDateRequest date, int ceremonyId, int currentUserId);
    }
}