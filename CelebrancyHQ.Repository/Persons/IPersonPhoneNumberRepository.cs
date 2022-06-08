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
    }
}