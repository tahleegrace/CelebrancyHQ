namespace CelebrancyHQ.Models.Exceptions.Persons
{
    /// <summary>
    /// An exception that occurs when a person already exists with the specified email address.
    /// </summary>
    public class PersonAlreadyExistsWithEmailAddressException : Exception
    {
        /// <summary>
        /// Gets the email address of the person.
        /// </summary>
        public string EmailAddress { get; }

        /// <summary>
        /// Creates a new instance of PersonAlreadyExistsWithEmailAddressException.
        /// </summary>
        /// <param name="emailAddress">The email address of the person.</param>
        public PersonAlreadyExistsWithEmailAddressException(string emailAddress)
        {
            this.EmailAddress = emailAddress;
        }
    }
}