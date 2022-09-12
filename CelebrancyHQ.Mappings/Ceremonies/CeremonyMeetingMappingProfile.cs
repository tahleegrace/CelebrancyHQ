using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Mappings.Ceremonies
{
    /// <summary>
    /// Defines mappings between ceremony meeting domain model and entity classes.
    /// </summary>
    public class CeremonyMeetingMappingProfile : Profile
    {
        public CeremonyMeetingMappingProfile()
        {
            CreateMap<CeremonyMeeting, CeremonyMeeting>();

            CreateMap<CeremonyMeeting, CeremonyMeetingDTO>()
                .ForMember(dest => dest.CeremonyTypeMeetingCode, source => source.MapFrom(item => item.CeremonyTypeMeeting.Code))
                .ForMember(dest => dest.CeremonyTypeMeetingName, source => source.MapFrom(item => item.CeremonyTypeMeeting.Name));

            CreateMap<CreateCeremonyMeetingRequest, CeremonyMeeting>();

            CreateMap<UpdateCeremonyMeetingRequest, CeremonyMeeting>()
                .ForMember(dest => dest.Name, source =>
                {
                    source.PreCondition(item => item.Name.Updated);
                    source.MapFrom(item => item.Name.Value);
                })
                .ForMember(dest => dest.Description, source =>
                {
                    source.PreCondition(item => item.Description.Updated);
                    source.MapFrom(item => item.Description.Value);
                })
                .ForMember(dest => dest.Date, source =>
                {
                    source.PreCondition(item => item.Date.Updated);
                    source.MapFrom(item => item.Date.Value);
                });
        }
    }
}