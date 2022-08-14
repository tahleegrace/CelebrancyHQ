using CelebrancyHQ.Entities;

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
        /// Gets the phone numbers for the specified person.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <returns>The phone numbers for the specified person.</returns>
        Task<List<PersonPhoneNumber>> GetPhoneNumbersForPerson(int personId);

        /// <summary>
        /// Gets the phone numbers for the specified persons.
        /// </summary>
        /// <param name="personIds">The IDs of the persons.</param>
        /// <returns>The phone numbers for the specified persons.</returns>
        Task<Dictionary<int, List<PersonPhoneNumber>>> GetPhoneNumbersForPersons(List<int> personIds);

        /// <summary>
        /// Creates new phone numbers for a person.
        /// </summary>
        /// <param name="phoneNumbers">The phone numbers.</param>
        /// <returns>The newly created phone numbers.</returns>
        Task<List<PersonPhoneNumber>> Create(List<PersonPhoneNumber> phoneNumbers);

        /// <summary>
        /// Updates the specified person phone numbers.
        /// </summary>
        /// <param name="phoneNumbers">The phone numbers.</param>
        Task Update(List<PersonPhoneNumber> phoneNumbers);

        /// <summary>
        /// Deletes the specified person phone numbers.
        /// </summary>
        /// <param name="phoneNumbers">The phone numbers.</param>
        Task Delete(List<PersonPhoneNumber> phoneNumbers);
    }
}