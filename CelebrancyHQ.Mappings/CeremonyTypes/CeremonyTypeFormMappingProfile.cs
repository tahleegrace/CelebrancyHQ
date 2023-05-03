using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.CeremonyTypes;

namespace CelebrancyHQ.Mappings.CeremonyTypes
{
    /// <summary>
    /// Defines mappings between ceremony type form domain model and entity classes.
    /// </summary>
    public class CeremonyTypeFormMappingProfile : Profile
    {
        public CeremonyTypeFormMappingProfile()
        {
            CreateMap<CeremonyTypeForm, CeremonyTypeFormDTO>();
        }
    }
}