﻿using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.CeremonyTypes;

namespace CelebrancyHQ.Mappings.CeremonyTypes
{
    /// <summary>
    /// Defines mappings between ceremony type domain model and entity classes.
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