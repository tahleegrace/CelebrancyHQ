using AutoMapper;

using CelebrancyHQ.Models.DTOs.Files;

namespace CelebrancyHQ.Mappings.Files
{
    /// <summary>
    /// Defines mappings between file domain model and entity classes.
    /// </summary>
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            CreateMap<CreateFileRequest, Entities.File>();

            CreateMap<Entities.File, FileDTO>();
        }
    }
}