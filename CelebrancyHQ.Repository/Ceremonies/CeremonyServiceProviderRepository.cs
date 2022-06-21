﻿using Microsoft.EntityFrameworkCore;

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
    }
}