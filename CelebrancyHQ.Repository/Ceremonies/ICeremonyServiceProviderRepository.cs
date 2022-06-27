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
        /// Gets whether the specified organisation is a service provider other than the specified type in the specified ceremony.
        /// </summary>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="codeToExclude">The ceremony type service provider code.</param>
        /// <returns>Whether the specified organisation is a service provider other than the specified type in the specified ceremony.</returns>
        Task<bool> OrganisationIsCeremonyServiceProviderOfOtherType(int organisationId, int ceremonyId, string codeToExclude);

        /// <summary>
        /// Gets whether the specified organisation is a service provider for any ceremonies other than the specified ceremony.
        /// </summary>
        /// <param name="organistionId">The ID of the organisation.</param>
        /// <param name="ceremonyToExcludeId">The ID of the ceremony.</param>
        /// <returns>Whether the specified organisation is a service provider for any ceremonies other than the specified ceremony.</returns>
        Task<bool> OrganisationIsServiceProviderForOtherCeremonies(int organistionId, int ceremonyToExcludeId);

        /// <summary>
        /// Creates a new ceremony service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The newly created ceremony service provider.</returns>
        Task<CeremonyServiceProvider> Create(CeremonyServiceProvider serviceProvider);

        /// <summary>
        /// Deletes the specified service provider.
        /// </summary>
        /// <param name="id">The ID of the service provider.</param>
        Task Delete(int id);
    }
}