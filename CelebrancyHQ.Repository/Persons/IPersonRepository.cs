using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Persons
{
    /// <summary>
    /// A persons repository.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Finds the person with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the person.</param>
        /// <returns>The person with the specified ID.</returns>
        Task<Person?> FindById(int id);
    }
}