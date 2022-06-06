using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Addresses;

namespace CelebrancyHQ.Mappings.Addresses
{
    /// <summary>
    /// Defines mappings between <see cref="CelebrancyHQ.Entities.Address" /> and <see cref="CelebrancyHQ.Models.DTOs.Addresses.AddressDTO" />.
    /// </summary>
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<Address, AddressDTO>();
        }
    }
}