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
    }
}