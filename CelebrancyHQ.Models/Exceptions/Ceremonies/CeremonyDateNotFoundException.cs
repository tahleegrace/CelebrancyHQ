namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony date is not found.
    /// </summary>
    public class CeremonyDateNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony date.
        /// </summary>
        public int CeremonyDateId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyDateNotFoundException.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony date.</param>
        public CeremonyDateNotFoundException(int ceremonyDateId)
            : base()
        {
            this.CeremonyDateId = ceremonyDateId;
        }
    }
}