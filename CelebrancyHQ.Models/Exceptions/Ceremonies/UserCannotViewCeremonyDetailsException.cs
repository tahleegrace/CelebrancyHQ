namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a user cannot view the details of a ceremony.
    /// </summary>
    public class UserCannotViewCeremonyDetailsException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony.
        /// </summary>
        public int CeremonyId { get; }

        /// <summary>
        /// Creates a new instance of UserCannotViewCeremonyDetailsException.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        public UserCannotViewCeremonyDetailsException(int ceremonyId)
            : base()
        {
            this.CeremonyId = ceremonyId;
        }
    }
}