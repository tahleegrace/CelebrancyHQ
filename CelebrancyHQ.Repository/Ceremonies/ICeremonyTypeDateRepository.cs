using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony type date repository.
    /// </summary>
    public interface ICeremonyTypeDateRepository
    {
        /// <summary>
        /// Finds the ceremony type date for the specified ceremony type and code.
        /// </summary>
        /// <param name="code">The code of the ceremony type.</param>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <returns>The ceremony type date with the specified code.</returns>
        Task<CeremonyTypeDate?> FindByCode(string code, int ceremonyTypeId);
    }
}