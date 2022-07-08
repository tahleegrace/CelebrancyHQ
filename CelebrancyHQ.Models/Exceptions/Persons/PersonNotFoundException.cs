namespace CelebrancyHQ.Models.Exceptions.Persons
{
    /// <summary>
    /// An exception that occurs when a person is not found.
    /// </summary>
    public class PersonNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the person.
        /// </summary>
        public int PersonId { get; }

        /// <summary>
        /// Creates a new instance of PersonNotFoundException.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        public PersonNotFoundException(int personId)
            : base()
        {
            this.PersonId = personId;
        }
    }
}