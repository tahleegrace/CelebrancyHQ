﻿using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Persons
{
    /// <summary>
    /// A person phone numbers repository.
    /// </summary>
    public interface IPersonPhoneNumberRepository
    {
        /// <summary>
        /// Gets the primary phone numbers for the participants in the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The primary phone numbers for the participants in the specified ceremony.</returns>
        Task<Dictionary<int, PersonPhoneNumber>> GetPrimaryPhoneNumbersForCeremonyParticipants(int ceremonyId);

        /// <summary>
        /// Creates new phone numbers for a person.
        /// </summary>
        /// <param name="phoneNumbers">The phone numbers.</param>
        /// <returns>The newly created phone numbers.</returns>
        Task<List<PersonPhoneNumber>> Create(List<PersonPhoneNumber> phoneNumbers);
    }
}