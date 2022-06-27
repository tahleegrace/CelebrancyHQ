namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony service provider is not found.
    /// </summary>
    public class CeremonyServiceProviderNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony service provider.
        /// </summary>
        public int CeremonyServiceProviderId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyServiceProviderNotFoundException.
        /// </summary>
        /// <param name="ceremonyServiceProviderId">The ID of the ceremony service provider.</param>
        public CeremonyServiceProviderNotFoundException(int ceremonyServiceProviderId)
            : base()
        {
            this.CeremonyServiceProviderId = ceremonyServiceProviderId;
        }
    }
}