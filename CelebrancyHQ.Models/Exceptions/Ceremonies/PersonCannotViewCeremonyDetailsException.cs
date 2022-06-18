namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a person cannot view the details of a ceremony.
    /// </summary>
    public class PersonCannotViewCeremonyDetailsException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony.
        /// </summary>
        public int CeremonyId { get; }

        /// <summary>
        /// Creates a new instance of PersonCannotViewCeremonyDetailsException.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        public PersonCannotViewCeremonyDetailsException(int ceremonyId)
            : base()
        {
            this.CeremonyId = ceremonyId;
        }
    }
}