using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Persons
{
    /// <summary>
    /// The persons repository.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of PersonRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public PersonRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the person with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the person.</param>
        /// <returns>The person with the specified ID.</returns>
        public async Task<Person?> FindById(int id)
        {
            var person = await this._context.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();

            return person;
        }
    }
}