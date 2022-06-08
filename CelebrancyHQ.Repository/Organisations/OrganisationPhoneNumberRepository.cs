using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Organisations
{
    /// <summary>
    /// The organisation phone numbers repository.
    /// </summary>
    public class OrganisationPhoneNumberRepository : IOrganisationPhoneNumberRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of OrganisationPhoneNumberRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public OrganisationPhoneNumberRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the primary phone number for the specified organisation.
        /// </summary>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <returns>The primary phone number for the specified organisation.</returns>
        public async Task<OrganisationPhoneNumber?> GetOrganisationPrimaryPhoneNumber(int organisationId)
        {
            var phoneNumber = await this._context.OrganisationPhoneNumbers.Where(p => p.OrganisationId == organisationId && !p.Deleted).FirstOrDefaultAsync();

            return phoneNumber;
        }
    }
}