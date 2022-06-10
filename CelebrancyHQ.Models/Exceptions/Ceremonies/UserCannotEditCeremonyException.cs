namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a user cannot edit a ceremony.
    /// </summary>
    public class UserCannotEditCeremonyException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony.
        /// </summary>
        public int CeremonyId { get; }

        /// <summary>
        /// Creates a new instance of UserCannotEditCeremonyException.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        public UserCannotEditCeremonyException(int ceremonyId)
            : base()
        {
            this.CeremonyId = ceremonyId;
        }
    }
}