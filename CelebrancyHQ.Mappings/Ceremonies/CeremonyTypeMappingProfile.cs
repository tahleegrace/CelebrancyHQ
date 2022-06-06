using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;

namespace CelebrancyHQ.Mappings.Ceremonies
{
    /// <summary>
    /// Defines mappings between <see cref="CelebrancyHQ.Entities.CeremonyType" /> and <see cref="CelebrancyHQ.Models.DTOs.Ceremonies.CeremonyTypeDTO" />.
    /// </summary>
    public class CeremonyTypeMappingProfile : Profile
    {
        public CeremonyTypeMappingProfile()
        {
            CreateMap<CeremonyType, CeremonyTypeDTO>()
                .ForMember(dest => dest.RestrictedToOrganisation, source => source.MapFrom(item => item.Organisation != null));
        }
    }
}