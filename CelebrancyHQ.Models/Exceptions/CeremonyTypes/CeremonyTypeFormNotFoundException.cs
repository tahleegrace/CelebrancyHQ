namespace CelebrancyHQ.Models.Exceptions.CeremonyTypes
{
    /// <summary>
    /// An exception that occurs when a ceremony type form is not found.
    /// </summary>
    public class CeremonyTypeFormNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony type form.
        /// </summary>
        public int CeremonyTypeFormId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeFormNotFoundException.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        public CeremonyTypeFormNotFoundException(int ceremonyTypeFormId)
            : base()
        {
            this.CeremonyTypeFormId = ceremonyTypeFormId;
        }
    }
}