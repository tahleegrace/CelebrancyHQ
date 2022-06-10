using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Mappings.Ceremonies
{
    /// <summary>
    /// Defines mappings between ceremony participant domain model and entity classes.
    /// </summary>
    public class CeremonyParticipantMappingProfile : Profile
    {
        public CeremonyParticipantMappingProfile()
        {
            CreateMap<CeremonyParticipant, CeremonyParticipantDTO>()
                .ForMember(dest => dest.Code, source => source.MapFrom(item => item.CeremonyTypeParticipant.Code))
                .ForMember(dest => dest.Name, source => source.MapFrom(item => item.CeremonyTypeParticipant.Name));
        }
    }
}