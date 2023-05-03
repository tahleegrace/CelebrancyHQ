namespace CelebrancyHQ.Models.Exceptions.CeremonyTypes
{
    /// <summary>
    /// An exception that occurs when a person cannot view the details of a ceremony type.
    /// </summary>
    public class PersonCannotViewCeremonyTypeDetailsException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony type.
        /// </summary>
        public int CeremonyTypeId { get; }

        /// <summary>
        /// Creates a new instance of PersonCannotViewCeremonyTypeDetailsException.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        public PersonCannotViewCeremonyTypeDetailsException(int ceremonyTypeId)
            : base()
        {
            this.CeremonyTypeId = ceremonyTypeId;
        }
    }
}