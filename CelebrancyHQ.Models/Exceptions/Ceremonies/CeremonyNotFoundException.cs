namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony is not found.
    /// </summary>
    public class CeremonyNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony.
        /// </summary>
        public int CeremonyId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyNotFoundException.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        public CeremonyNotFoundException(int ceremonyId)
            : base()
        {
            this.CeremonyId = ceremonyId;
        }
    }
}