using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Mappings.Ceremonies
{
    /// <summary>
    /// Defines mappings between ceremony service provider domain model and entity classes.
    /// </summary>
    public class CeremonyServiceProviderMappingProfile : Profile
    {
        public CeremonyServiceProviderMappingProfile()
        {
            CreateMap<CeremonyServiceProvider, CeremonyServiceProviderDTO>()
                .ForMember(dest => dest.Code, source => source.MapFrom(item => item.CeremonyTypeServiceProvider.Code))
                .ForMember(dest => dest.Name, source => source.MapFrom(item => item.CeremonyTypeServiceProvider.Name))
                .ForMember(dest => dest.OrganisationName, source => source.MapFrom(item => item.Organisation.Name))
                .ForMember(dest => dest.EmailAddress, source => source.MapFrom(item => item.Organisation.EmailAddress))
                .ForMember(dest => dest.Website, source => source.MapFrom(item => item.Organisation.Website));

            CreateMap<CreateCeremonyServiceProviderRequest, Organisation>()
                .ForMember(dest => dest.Notes, source => source.Ignore())
                .ForMember(dest => dest.Address, source => source.Ignore());
        }
    }
}