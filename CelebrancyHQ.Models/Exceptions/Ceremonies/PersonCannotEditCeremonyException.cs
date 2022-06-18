namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a person cannot edit a ceremony.
    /// </summary>
    public class PersonCannotEditCeremonyException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony.
        /// </summary>
        public int CeremonyId { get; }

        /// <summary>
        /// Creates a new instance of PersonCannotEditCeremonyException.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        public PersonCannotEditCeremonyException(int ceremonyId)
            : base()
        {
            this.CeremonyId = ceremonyId;
        }
    }
}