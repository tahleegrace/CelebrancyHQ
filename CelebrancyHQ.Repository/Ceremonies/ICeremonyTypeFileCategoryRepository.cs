using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony type file category repository.
    /// </summary>
    public interface ICeremonyTypeFileCategoryRepository
    {
        /// <summary>
        /// Finds the ceremony type file category with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the ceremony type file category.</param>
        /// <returns>The ceremony type file category with the specified ID.</returns>
        Task<CeremonyTypeFileCategory?> FindById(int id);

        /// <summary>
        /// Finds the file category for the specified ceremony type with the specified code.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="code">The code of the file category.</param>
        /// <returns>The file category for the specified ceremony type with the specified code.</returns>
        Task<CeremonyTypeFileCategory?> FindByCode(int ceremonyTypeId, string code);
    }
}