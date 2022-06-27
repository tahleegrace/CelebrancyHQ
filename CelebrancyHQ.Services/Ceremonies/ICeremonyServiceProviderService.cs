using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functions for managing ceremony service providers.
    /// </summary>
    public interface ICeremonyServiceProviderService
    {
        /// <summary>
        /// Creates a new ceremony service provider.
        /// </summary>
        /// <param name="request">The service provider.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created service provider.</returns>
        Task<CeremonyServiceProviderDTO> Create(CreateCeremonyServiceProviderRequest request, int ceremonyId, int currentUserId);

        /// <summary>
        /// Deletes the specified ceremony service provider.
        /// </summary>
        /// <param name="serviceProviderId">The ID of the service provider.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task Delete(int serviceProviderId, int currentUserId);
    }
}