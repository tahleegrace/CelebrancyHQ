namespace CelebrancyHQ.Models.DTOs.Persons
{
    /// <summary>
    /// Stores details about a user.
    /// </summary>
    public class PersonDTO
    {
        // TODO: Add PreferredName, Title and Gender to this class.
        /// <summary>
        /// Gets or sets the ID of the person.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the business name of the user.
        /// </summary>
        public string? BusinessName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string EmailAddress { get; set; }
    }
}