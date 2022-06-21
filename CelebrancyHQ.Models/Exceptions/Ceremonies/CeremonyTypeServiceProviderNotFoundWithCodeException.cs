namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony type service provider is not found with the specified code.
    /// </summary>
    public class CeremonyTypeServiceProviderNotFoundWithCodeException : Exception
    {
        /// <summary>
        /// Gets the code of the service provider.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeServiceProviderNotFoundWithCodeException.
        /// </summary>
        /// <param name="code">The code of the service provider.</param>
        public CeremonyTypeServiceProviderNotFoundWithCodeException(string code)
        {
            this.Code = code;
        }
    }
}