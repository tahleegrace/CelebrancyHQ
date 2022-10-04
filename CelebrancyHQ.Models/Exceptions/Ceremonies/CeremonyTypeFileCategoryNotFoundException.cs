namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony type file category is not found.
    /// </summary>
    public class CeremonyTypeFileCategoryNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ceremony type file category.
        /// </summary>
        public int CeremonyTypeFileCategoryId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeFileCategoryNotFoundException.
        /// </summary>
        /// <param name="ceremonyTypeFileCategoryId">The ID of the ceremony type file category.</param>
        public CeremonyTypeFileCategoryNotFoundException(int ceremonyTypeFileCategoryId)
            : base()
        {
            this.CeremonyTypeFileCategoryId = ceremonyTypeFileCategoryId;
        }
    }
}