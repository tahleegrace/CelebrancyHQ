namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony file is not found.
    /// </summary>
    public class CeremonyFileNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the file.
        /// </summary>
        public int FileId { get; }

        /// <summary>
        /// Creates a new instance of CeremonyFileNotFoundException.
        /// </summary>
        /// <param name="personId">The ID of the file.</param>
        public CeremonyFileNotFoundException(int fileId)
            : base()
        {
            this.FileId = fileId;
        }
    }
}