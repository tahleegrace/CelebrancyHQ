using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Addresses;

namespace CelebrancyHQ.Mappings.Addresses
{
    /// <summary>
    /// Defines mappings between address domain model and entity classes.
    /// </summary>
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<Address, AddressDTO>();

            CreateMap<CreateAddressRequest, Address>();
        }
    }
}