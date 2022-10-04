using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Mappings.Ceremonies
{
    /// <summary>
    /// Defines mappings between ceremony type file category domain model and entity classes.
    /// </summary>
    public class CeremonyTypeFileCategoryMappingProfile : Profile
    {
        public CeremonyTypeFileCategoryMappingProfile()
        {
            CreateMap<CeremonyTypeFileCategory, CeremonyTypeFileCategoryDTO>();
        }
    }
}