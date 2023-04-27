namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony meeting question file is not found.
    /// </summary>
    public class CeremonyMeetingQuestionFileNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the file.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Creates a new instance of CeremonyMeetingQuestionFileNotFoundException.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        public CeremonyMeetingQuestionFileNotFoundException(int id)
            : base()
        {
            this.Id = id;
        }
    }
}