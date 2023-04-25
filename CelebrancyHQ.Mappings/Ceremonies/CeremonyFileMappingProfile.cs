using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Mappings.Ceremonies
{
    /// <summary>
    /// Defines mappings between ceremony file category domain model and entity classes.
    /// </summary>
    public class CeremonyFileMappingProfile : Profile
    {
        public CeremonyFileMappingProfile()
        {
            CreateMap<CeremonyFile, CeremonyFile>();

            CreateMap<CreateCeremonyFileRequest, CeremonyFile>();

            CreateMap<CeremonyFile, CeremonyFileDTO>();

            CreateMap<UpdateCeremonyFileRequest, CeremonyFile>();
        }
    }
}