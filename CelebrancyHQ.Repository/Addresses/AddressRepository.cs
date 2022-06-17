using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Addresses
{
    /// <summary>
    /// The address repository.
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of AddressRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public AddressRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Finds the address with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the address.</param>
        /// <returns>The address with the specified ID.</returns>
        public async Task<Address?> FindById(int id)
        {
            return await this._context.Addresses.Where(a => a.Id == id && !a.Deleted).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates a new address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>The newly created address.</returns>
        public async Task<Address> Create(Address address)
        {
            address.Created = DateTime.UtcNow;
            address.Updated = DateTime.UtcNow;

            this._context.Addresses.Add(address);

            await this._context.SaveChangesAsync();

            var newAddress = await this.FindById(address.Id);
            return newAddress;
        }
    }
}