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
            CreateMap<CreateFileRequest, Entities.File>()
                .ForMember(dest => dest.Name, source => source.MapFrom(item => item.FileData.FileName))
                .ForMember(dest => dest.ContentType, source => source.MapFrom(item => item.FileData.ContentType))
                .ForMember(dest => dest.FileData, source => source.Ignore());

            CreateMap<Entities.File, FileDTO>();

            CreateMap<Entities.File, DownloadFileDTO>();
        }
    }
}