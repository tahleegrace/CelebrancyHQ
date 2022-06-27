using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony service providers repository.
    /// </summary>
    public class CeremonyServiceProviderRepository : ICeremonyServiceProviderRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyServiceProviderRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyServiceProviderRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the ceremony service provider with the specified ID.
        /// </summary>
        /// <param name="ceremonyServiceProviderId">The ID of the ceremony service provider.</param>
        /// <returns>The ceremony service provider with the specified ID.</returns>
        public async Task<CeremonyServiceProvider?> FindById(int ceremonyServiceProviderId)
        {
            return await this._context.CeremonyServiceProviders.Include(csp => csp.CeremonyTypeServiceProvider)
                                                               .Include(csp => csp.Organisation)
                                                               .Where(csp => csp.Id == ceremonyServiceProviderId && !csp.Deleted)
                                                               .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets whether the specified organisation is a service provider of the specified type in the specified ceremony.
        /// </summary>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="code">The ceremony type service provider code.</param>
        /// <returns>Whether the specified organisation is a service provider of the specified type in the specified ceremony.</returns>
        public async Task<bool> OrganisationIsCeremonyServiceProvider(int organisationId, int ceremonyId, string code)
        {
            return await this._context.CeremonyServiceProviders.Include(csp => csp.CeremonyTypeServiceProvider)
                                                               .Where(csp => csp.OrganisationId == organisationId && csp.CeremonyId == ceremonyId
                                                                          && csp.CeremonyTypeServiceProvider.Code == code && !csp.Deleted)
                                                               .AnyAsync();
        }

        /// <summary>
        /// Gets whether the specified organisation is a service provider other than the specified type in the specified ceremony.
        /// </summary>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="codeToExclude">The ceremony type service provider code.</param>
        /// <returns>Whether the specified organisation is a service provider other than the specified type in the specified ceremony.</returns>
        public async Task<bool> OrganisationIsCeremonyServiceProviderOfOtherType(int organisationId, int ceremonyId, string codeToExclude)
        {
            return await this._context.CeremonyServiceProviders.Include(csp => csp.CeremonyTypeServiceProvider)
                                                               .Where(csp => csp.OrganisationId == organisationId && csp.CeremonyId == ceremonyId
                                                                          && csp.CeremonyTypeServiceProvider.Code != codeToExclude && !csp.Deleted)
                                                               .AnyAsync();
        }

        /// <summary>
        /// Gets whether the specified organisation is a service provider for any ceremonies other than the specified ceremony.
        /// </summary>
        /// <param name="organistionId">The ID of the organisation.</param>
        /// <param name="ceremonyToExcludeId">The ID of the ceremony.</param>
        /// <returns>Whether the specified organisation is a service provider for any ceremonies other than the specified ceremony.</returns>
        public async Task<bool> OrganisationIsServiceProviderForOtherCeremonies(int organistionId, int ceremonyToExcludeId)
        {
            return await this._context.CeremonyServiceProviders.Where(csp => csp.OrganisationId == organistionId && csp.CeremonyId != ceremonyToExcludeId
                                                                          && !csp.Deleted)
                                                               .AnyAsync();
        }

        /// <summary>
        /// Creates a new ceremony service provider.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The newly created ceremony service provider.</returns>
        public async Task<CeremonyServiceProvider> Create(CeremonyServiceProvider serviceProvider)
        {
            serviceProvider.Created = DateTime.UtcNow;
            serviceProvider.Updated = DateTime.UtcNow;

            this._context.CeremonyServiceProviders.Add(serviceProvider);

            await this._context.SaveChangesAsync();

            var newServiceProvider = await FindById(serviceProvider.Id);
            return newServiceProvider;
        }

        /// <summary>
        /// Deletes the specified service provider.
        /// </summary>
        /// <param name="id">The ID of the service provider.</param>
        public async Task Delete(int id)
        {
            var serviceProvider = await this.FindById(id);
            serviceProvider.Updated = DateTime.UtcNow;
            serviceProvider.Deleted = true;
            await this._context.SaveChangesAsync();
        }
    }
}