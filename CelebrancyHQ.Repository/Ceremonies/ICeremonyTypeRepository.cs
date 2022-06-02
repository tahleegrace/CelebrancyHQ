using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony types repository.
    /// </summary>
    public interface ICeremonyTypeRepository
    {
        /// <summary>
        /// Finds the ceremony types that can be offered by the specified organisation.
        /// </summary>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <returns>The ceremony types that can be offered by the specified organisation.</returns>
        Task<List<CeremonyType>> FindByOrganisationId(int? organisationId);
    }
}