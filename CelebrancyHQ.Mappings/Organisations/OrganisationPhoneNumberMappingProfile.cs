using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.PhoneNumbers;

namespace CelebrancyHQ.Mappings.Organisations
{
    /// <summary>
    /// Defines mappings between organisation phone number domain model and entity classes.
    /// </summary>
    public class OrganisationPhoneNumberMappingProfile : Profile
    {
        public OrganisationPhoneNumberMappingProfile()
        {
            CreateMap<OrganisationPhoneNumber, PhoneNumberDTO>();

            CreateMap<CreateOrUpdatePhoneNumberRequest, OrganisationPhoneNumber>();
        }
    }
}