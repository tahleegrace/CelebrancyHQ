namespace CelebrancyHQ.Models.Exceptions.CeremonyTypes
{
    /// <summary>
    /// An exception that occurs when a ceremony type is not found.
    /// </summary>
    public class CeremonyTypeNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony type.
        /// </summary>
        public int CeremonyTypeId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeNotFoundException.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        public CeremonyTypeNotFoundException(int ceremonyTypeId)
            : base()
        {
            CeremonyTypeId = ceremonyTypeId;
        }
    }
}