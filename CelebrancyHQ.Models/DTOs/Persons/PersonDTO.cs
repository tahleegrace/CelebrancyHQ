﻿using CelebrancyHQ.Models.DTOs.Addresses;
using CelebrancyHQ.Models.DTOs.PhoneNumbers;

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
        /// Gets or sets the first name of the person.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle names of the person.
        /// </summary>
        public string? MiddleNames { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
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
        /// Gets or sets the organisation name of the person.
        /// </summary>
        public string? OrganisationName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the person.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the person.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the primary phone number of the person.
        /// </summary>
        public string? PrimaryPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers of the person.
        /// </summary>
        public List<PhoneNumberDTO> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the address of the person.
        /// </summary>
        public AddressDTO? Address { get; set; }
    }
}