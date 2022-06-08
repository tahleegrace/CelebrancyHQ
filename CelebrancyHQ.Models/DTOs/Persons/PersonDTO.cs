namespace CelebrancyHQ.Models.DTOs.Persons
{
    /// <summary>
    /// Stores details about a user.
    /// </summary>
    public class PersonDTO
    {
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
        /// Gets or sets the preferred name of the person.
        /// </summary>
        public string? PreferredName { get; set; }

        /// <summary>
        /// Gets or sets the title of the person.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the gender the person identifies as.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the organisation name of the user.
        /// </summary>
        public string? OrganisationName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the primary phone number of the user.
        /// </summary>
        public string? PrimaryPhoneNumber { get; set; }
    }
}