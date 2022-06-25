using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Organisations
{
    /// <summary>
    /// An organisation phone numbers repository.
    /// </summary>
    public interface IOrganisationPhoneNumberRepository
    {
        /// <summary>
        /// Gets the primary phone number for the specified organisation.
        /// </summary>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <returns>The primary phone number for the specified organisation.</returns>
        Task<OrganisationPhoneNumber?> GetOrganisationPrimaryPhoneNumber(int organisationId);

        /// <summary>
        /// Creates new phone numbers for an organisation.
        /// </summary>
        /// <param name="phoneNumbers">The phone numbers.</param>
        /// <returns>The newly created phone numbers.</returns>
        Task<List<OrganisationPhoneNumber>> Create(List<OrganisationPhoneNumber> phoneNumbers);
    }
}