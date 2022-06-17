using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.PhoneNumbers;

namespace CelebrancyHQ.Mappings.Persons
{
    /// <summary>
    /// Defines mappings between person phone number domain model and entity classes.
    /// </summary>
    public class PersonPhoneNumberMappingProfile : Profile
    {
        public PersonPhoneNumberMappingProfile()
        {
            CreateMap<PersonPhoneNumber, PhoneNumberDTO>();

            CreateMap<CreatePhoneNumberRequest, PersonPhoneNumber>();
        }
    }
}