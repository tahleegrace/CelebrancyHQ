using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Users
{
    /// <summary>
    /// The users repository.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private CelebrancyHQContext _context { get; set; } 

        /// <summary>
        /// Creates a new instance of UserRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public UserRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the user with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user with the specified ID.</returns>
        public async Task<User?> FindById(int id)
        {
            var user = await this._context.Users.Include(u => u.Person)
                                                .Include(u => u.Person.Organisation)
                                                .Where(u => u.Id == id && !u.Deleted)
                                                .FirstOrDefaultAsync();

            return user;
        }

        /// <summary>
        /// Finds the user with the specified email address.
        /// </summary>
        /// <param name="emailAddress">The email address of the user.</param>
        /// <returns>The user with the specified email address.</returns>
        public async Task<User?> FindByEmailAddress(string emailAddress)
        {
            var user = await this._context.Users.Include(u => u.Person)
                                                .Include(u => u.Person.Organisation)
                                                .Where(u => u.EmailAddress == emailAddress && !u.Deleted).FirstOrDefaultAsync();

            return user;
        }
    }
}