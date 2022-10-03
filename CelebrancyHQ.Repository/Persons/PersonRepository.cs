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
            var person = await this._context.Persons.Include(p => p.Address)
                                                    .Where(p => p.Id == id && !p.Deleted)
                                                    .FirstOrDefaultAsync();

            return person;
        }

        /// <summary>
        /// Finds the person with the specified email address.
        /// </summary>
        /// <param name="emailAddress">The email address of the person.</param>
        /// <returns>The person with the specified email address.</returns>
        public async Task<Person?> FindByEmailAddress(string emailAddress)
        {
            return await this._context.Persons.Include(p => p.Address)
                                              .Where(p => p.EmailAddress == emailAddress && !p.Deleted)
                                              .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets whether a person exists with the specified email address.
        /// </summary>
        /// <param name="emailAddress">The email address of the person.</param>
        /// <returns>Whether a person exists with the specified email address.</returns>
        public async Task<bool> PersonExistsWithEmailAddress(string emailAddress)
        {
            return await this._context.Persons.Where(p => p.EmailAddress == emailAddress && !p.Deleted).AnyAsync();
        }

        /// <summary>
        /// Creates a new person.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>The newly created person.</returns>
        public async Task<Person> Create(Person person)
        {
            person.Created = DateTime.UtcNow;
            person.Updated = DateTime.UtcNow;

            this._context.Persons.Add(person);

            await this._context.SaveChangesAsync();

            var newPerson = await FindById(person.Id);
            return newPerson;
        }

        /// <summary>
        /// Updates the details of the specified person.
        /// </summary>
        /// <param name="person">The person.</param>
        public async Task Update(Person person)
        {
            person.Updated = DateTime.UtcNow;
            this._context.Entry(person).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the person with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the person.</param>
        public async Task Delete(int id)
        {
            var person = await FindById(id);

            if (person.Address != null)
            {
                person.Address.Updated = DateTime.UtcNow;
                person.Address.Deleted = true;
            }

            var phoneNumbers = await this._context.PersonPhoneNumbers.Where(pp => pp.PersonId == id && !pp.Deleted).ToListAsync();

            foreach (var phoneNumber in phoneNumbers)
            {
                phoneNumber.Updated = DateTime.UtcNow;
                phoneNumber.Deleted = true;
            }

            person.Updated = DateTime.UtcNow;
            person.Deleted = true;

            await this._context.SaveChangesAsync();
        }
    }
}