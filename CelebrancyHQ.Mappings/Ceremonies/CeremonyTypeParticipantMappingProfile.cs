using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.CeremonyTypes;

namespace CelebrancyHQ.Mappings.Ceremonies
{
    /// <summary>
    /// Defines mappings between ceremony type participant domain model and entity classes.
    /// </summary>
    public class CeremonyTypeParticipantMappingProfile : Profile
    {
        public CeremonyTypeParticipantMappingProfile()
        {
            CreateMap<CeremonyTypeParticipant, CeremonyTypeParticipantDTO>();
        }
    }
}