using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.CeremonyTypes
{
    /// <summary>
    /// A ceremony type form repository.
    /// </summary>
    public interface ICeremonyTypeFormRepository
    {
        /// <summary>
        /// Gets the ceremony type form with the specified ID.
        /// </summary>
        /// <param name="formId">The ID of the form.</param>
        /// <returns>The ceremony type form with the specified ID.</returns>
        Task<CeremonyTypeForm?> FindById(int formId);

        /// <summary>
        /// Finds the ceremony type forms that can be offered by the specified organisation.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <returns>The ceremony type forms that can be offered by the specified organisation for the specified ceremony type.</returns>
        Task<List<CeremonyTypeForm>> FindByOrganisationId(int ceremonyTypeId, int? organisationId);
    }
}