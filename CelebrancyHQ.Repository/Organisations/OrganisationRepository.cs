using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Organisations
{
    /// <summary>
    /// The organisations repository.
    /// </summary>
    public class OrganisationRepository : IOrganisationRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of OrganisationRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public OrganisationRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the organisation with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the organisation.</param>
        /// <returns>The organisation with the specified ID.</returns>
        public async Task<Organisation?> FindById(int id)
        {
            var organisation = await this._context.Organisations.Include(o => o.Address)
                                                                .Where(o => o.Id == id && !o.Deleted).FirstOrDefaultAsync();

            return organisation;
        }

        /// <summary>
        /// Finds the organisation with the specified name.
        /// </summary>
        /// <param name="name">The name of the organisation.</param>
        /// <returns>The organisation with the specified name.</returns>
        public async Task<Organisation?> FindByName(string name)
        {
            return await this._context.Organisations.Include(o => o.Address)
                                                    .Where(o => o.Name == name && !o.Deleted)
                                                    .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates a new organisation.
        /// </summary>
        /// <param name="person">The organisation.</param>
        /// <returns>The newly created organisation.</returns>
        public async Task<Organisation> Create(Organisation organisation)
        {
            organisation.Created = DateTime.UtcNow;
            organisation.Updated = DateTime.UtcNow;

            this._context.Organisations.Add(organisation);

            await this._context.SaveChangesAsync();

            var newOrganisation = await FindById(organisation.Id);
            return newOrganisation;
        }

        /// <summary>
        /// Deletes the organisation with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the organisation.</param>
        public async Task Delete(int id)
        {
            var organisation = await FindById(id);

            if (organisation.Address != null)
            {
                organisation.Address.Updated = DateTime.UtcNow;
                organisation.Address.Deleted = true;
            }

            var phoneNumbers = await this._context.OrganisationPhoneNumbers.Where(op => op.OrganisationId == id && !op.Deleted).ToListAsync();

            foreach (var phoneNumber in phoneNumbers)
            {
                phoneNumber.Updated = DateTime.UtcNow;
                phoneNumber.Deleted = true;
            }

            organisation.Updated = DateTime.UtcNow;
            organisation.Deleted = true;

            await this._context.SaveChangesAsync();
        }
    }
}