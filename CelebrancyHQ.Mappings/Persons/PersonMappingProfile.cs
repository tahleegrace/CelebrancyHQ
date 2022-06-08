using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.Persons;

namespace CelebrancyHQ.Mappings.Persons
{
    /// <summary>
    /// Defines mappings between <see cref="CelebrancyHQ.Entities.Person" /> and <see cref="CelebrancyHQ.Models.DTOs.Persons.PersonDTO" />.
    /// </summary>
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonDTO>()
                .ForMember(dest => dest.PersonId, source => source.MapFrom(item => item.Id))
                .ForMember(dest => dest.OrganisationName, source => source.MapFrom(item => item.Organisation != null ? item.Organisation.Name : null));

            CreateMap<Person, CeremonyParticipantDTO>()
                .ForMember(dest => dest.PersonId, source => source.MapFrom(item => item.Id))
                .ForMember(dest => dest.OrganisationName, source => source.MapFrom(item => item.Organisation != null ? item.Organisation.Name : null));
        }
    }
}