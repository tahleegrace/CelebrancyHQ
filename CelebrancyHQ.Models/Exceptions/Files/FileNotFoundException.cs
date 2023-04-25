namespace CelebrancyHQ.Models.Exceptions.Files
{
    /// <summary>
    /// An exception that occurs when a file is not found.
    /// </summary>
    public class FileNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the file.
        /// </summary>
        public int FileId { get; }

        /// <summary>
        /// Creates a new instance of FileNotFoundException.
        /// </summary>
        /// <param name="personId">The ID of the file.</param>
        public FileNotFoundException(int fileId)
            : base()
        {
            this.FileId = fileId;
        }
    }
}