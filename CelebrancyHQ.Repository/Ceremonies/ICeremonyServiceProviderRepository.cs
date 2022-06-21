using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony service provider repository.
    /// </summary>
    public interface ICeremonyServiceProviderRepository
    {
        /// <summary>
        /// Gets the ceremony service provider with the specified ID.
        /// </summary>
        /// <param name="ceremonyServiceProviderId">The ID of the ceremony service provider.</param>
        /// <returns>The ceremony service provider with the specified ID.</returns>
        Task<CeremonyServiceProvider?> FindById(int ceremonyServiceProviderId);

        /// <summary>
        /// Creates a new ceremony service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The newly created ceremony service provider.</returns>
        Task<CeremonyServiceProvider> Create(CeremonyServiceProvider serviceProvider);
    }
}