using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Mappings.Ceremonies
{
    // <summary>
    /// Defines mappings between ceremony meeting domain model and entity classes.
    /// </summary>
    public class CeremonyMeetingMappingProfile : Profile
    {
        public CeremonyMeetingMappingProfile()
        {
            CreateMap<CeremonyMeeting, CeremonyMeetingDTO>()
                .ForMember(dest => dest.Code, source => source.MapFrom(item => item.CeremonyTypeMeeting.Code))
                .ForMember(dest => dest.Name, source => source.MapFrom(item => item.CeremonyTypeMeeting.Name));

            CreateMap<CreateCeremonyMeetingRequest, CeremonyMeeting>();
        }
    }
}