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
        /// Gets whether the specified organisation is a service provider of the specified type in the specified ceremony.
        /// </summary>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="code">The ceremony type service provider code.</param>
        /// <returns>Whether the specified organisation is a service provider of the specified type in the specified ceremony.</returns>
        Task<bool> OrganisationIsCeremonyServiceProvider(int organisationId, int ceremonyId, string code);

        /// <summary>
        /// Creates a new ceremony service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The newly created ceremony service provider.</returns>
        Task<CeremonyServiceProvider> Create(CeremonyServiceProvider serviceProvider);
    }
}