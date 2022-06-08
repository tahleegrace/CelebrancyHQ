using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Organisations;

namespace CelebrancyHQ.Mappings.Organisations
{
    /// <summary>
    /// Defines mappings between <see cref="CelebrancyHQ.Entities.Organisation" /> and <see cref="CelebrancyHQ.Models.DTOs.Organisations.OrganisationKeyDetailsDTO" />.
    /// </summary>
    public class OrganisationMappingProfile : Profile
    {
        public OrganisationMappingProfile()
        {
            CreateMap<Organisation, OrganisationKeyDetailsDTO>();
        }
    }
}