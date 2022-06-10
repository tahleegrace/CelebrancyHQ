using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Organisations;

namespace CelebrancyHQ.Mappings.Organisations
{
    /// <summary>
    /// Defines mappings between organisation domain model and entity classes.
    /// </summary>
    public class OrganisationMappingProfile : Profile
    {
        public OrganisationMappingProfile()
        {
            CreateMap<Organisation, OrganisationKeyDetailsDTO>();
        }
    }
}