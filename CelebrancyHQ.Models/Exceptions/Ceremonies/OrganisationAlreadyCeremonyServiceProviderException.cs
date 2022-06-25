namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when an organisation has already been added as a service provider of a specified type to a ceremony.
    /// </summary>
    public class OrganisationAlreadyCeremonyServiceProviderException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony.
        /// </summary>
        public int CeremonyId { get; }

        /// <summary>
        /// Gets the ceremony type service provider code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Creates a new instance of OrganisationAlreadyCeremonyServiceProviderExceptio.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="code">The ceremony type service provider code.</param>
        public OrganisationAlreadyCeremonyServiceProviderException(int ceremonyId, string code)
            : base()
        {
            this.CeremonyId = ceremonyId;
            this.Code = code;
        }
    }
}