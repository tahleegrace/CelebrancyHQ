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

        /// <summary>
        /// Gets the phone numbers for the specified organisation.
        /// </summary>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <returns>The phone numbers for the specified organisation.</returns>
        public async Task<List<OrganisationPhoneNumber>> GetPhoneNumbersForOrganisation(int organisationId)
        {
            return await this._context.OrganisationPhoneNumbers.Where(pp => pp.OrganisationId == organisationId && !pp.Deleted).ToListAsync();
        }

        /// <summary>
        /// Creates new phone numbers for an organisation.
        /// </summary>
        /// <param name="phoneNumbers">The phone numbers.</param>
        /// <returns>The newly created phone numbers.</returns>
        public async Task<List<OrganisationPhoneNumber>> Create(List<OrganisationPhoneNumber> phoneNumbers)
        {
            if (phoneNumbers == null || phoneNumbers.Count == 0)
            {
                return new List<OrganisationPhoneNumber>();
            }

            foreach (var phoneNumber in phoneNumbers)
            {
                phoneNumber.Created = DateTime.UtcNow;
                phoneNumber.Updated = DateTime.UtcNow;

                this._context.OrganisationPhoneNumbers.Add(phoneNumber);
            }

            await this._context.SaveChangesAsync();

            return phoneNumbers;
        }
    }
}