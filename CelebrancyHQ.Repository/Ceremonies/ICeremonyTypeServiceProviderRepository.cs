using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony type service provider repository.
    /// </summary>
    public interface ICeremonyTypeServiceProviderRepository
    {
        /// <summary>
        /// Finds the ceremony type service provider for the specified ceremony type with the specified code.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="code">The code of the ceremony type service provider.</param>
        /// <returns>The ceremony type service provider for the specified ceremony type with the specified code.</returns>
        Task<CeremonyTypeServiceProvider?> FindByCode(int ceremonyTypeId, string code);
    }
}