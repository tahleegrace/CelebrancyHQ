namespace CelebrancyHQ.Services.Authentication
{
    /// <summary>
    /// A service that generates unique codes.
    /// </summary>
    public interface IUniqueCodeGenerationService
    {
        /// <summary>
        /// Generates a unique code.
        /// </summary>
        /// <param name="length">The length of the unique code.</param>
        string GenerateUniqueCode(int length);
    }
}