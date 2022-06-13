using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Mappings.Ceremonies
{
    /// <summary>
    /// Defines mappings between ceremony date domain model and entity classes.
    /// </summary>
    public class CeremonyDateMappingProfile : Profile
    {
        public CeremonyDateMappingProfile()
        {
            CreateMap<CeremonyDate, CeremonyDateDTO>()
                .ForMember(dest => dest.Code, source => source.MapFrom(item => item.CeremonyTypeDate.Code))
                .ForMember(dest => dest.Name, source => source.MapFrom(item => item.CeremonyTypeDate.Name));

            CreateMap<UpdateCeremonyDateRequest, CeremonyDate>();

            CreateMap<CreateCeremonyDateRequest, CeremonyDate>()
                .ForMember(dest => dest.CustomName, source => source.MapFrom(item => item.Name));
        }
    }
}