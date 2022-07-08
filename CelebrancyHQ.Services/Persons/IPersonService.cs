using CelebrancyHQ.Models.DTOs.Persons;

namespace CelebrancyHQ.Services.Persons
{
    /// <summary>
    /// A service that provides functions for managing persons.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Updates the details of the specified person.
        /// </summary>
        /// <param name="request">The person.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        Task Update(UpdatePersonRequest request, int currentUserId);
    }
}