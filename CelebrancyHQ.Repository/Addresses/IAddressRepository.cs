using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Addresses
{
    /// <summary>
    /// An addresses repository.
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// Finds the address with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the address.</param>
        /// <returns>The address with the specified ID.</returns>
        Task<Address?> FindById(int id);

        /// <summary>
        /// Creates a new address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>The newly created address.</returns>
        Task<Address> Create(Address address);

        /// <summary>
        /// Updates the details of the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        Task Update(Address address);
    }
}