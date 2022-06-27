using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Mappings.Ceremonies
{
    /// <summary>
    /// Defines mappings between ceremony domain model and entity classes.
    /// </summary>
    public class CeremonyMappingProfile : Profile
    {
        public CeremonyMappingProfile()
        {
            CreateMap<Ceremony, CeremonySummaryDTO>();

            CreateMap<Ceremony, CeremonyKeyDetailsDTO>()
                .ForMember(dest => dest.CeremonyTypeId, src => src.MapFrom(src => src.CeremonyTypeId))
                .ForMember(dest => dest.CeremonyTypeName, src => src.MapFrom(src => src.CeremonyType.Name))
                .ForMember(dest => dest.CeremonyTypeCode, src => src.MapFrom(src => src.CeremonyType.Code));

            CreateMap<UpdateCeremonyRequest, Ceremony>();
        }
    }
}