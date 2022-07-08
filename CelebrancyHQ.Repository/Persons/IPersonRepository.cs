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

        /// <summary>
        /// Finds the person with the specified email address.
        /// </summary>
        /// <param name="emailAddress">The email address of the person.</param>
        /// <returns>The person with the specified email address.</returns>
        Task<Person?> FindByEmailAddress(string emailAddress);

        /// <summary>
        /// Gets whether a person exists with the specified email address.
        /// </summary>
        /// <param name="emailAddress">The email address of the person.</param>
        /// <returns>Whether a person exists with the specified email address.</returns>
        Task<bool> PersonExistsWithEmailAddress(string emailAddress);

        /// <summary>
        /// Creates a new person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>The newly created person.</returns>
        Task<Person> Create(Person person);

        /// <summary>
        /// Updates the details of the specified person.
        /// </summary>
        /// <param name="person">The person.</param>
        Task Update(Person person);

        /// <summary>
        /// Deletes the person with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the person.</param>
        Task Delete(int id);
    }
}