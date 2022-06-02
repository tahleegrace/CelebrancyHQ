using AutoMapper;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.Persons;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functions for managing the types of ceremonies that can be offered.
    /// </summary>
    public class CeremonyTypeService : ICeremonyTypeService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ICeremonyTypeRepository _ceremonyTypeRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyTypeService.
        /// </summary>
        /// <param name="userRepository">The users repository.</param>
        /// <param name="personRepository">The persons repository.</param>
        /// <param name="ceremonyTypeRepository">The ceremony types repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyTypeService(IUserRepository userRepository, IPersonRepository personRepository, ICeremonyTypeRepository ceremonyTypeRepository,
            IMapper mapper)
        {
            this._userRepository = userRepository;
            this._personRepository = personRepository;
            this._ceremonyTypeRepository = ceremonyTypeRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Gets the types of ceremonies the specified user can offer.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The types of ceremonies the user can offer.</returns>
        public async Task<List<CeremonyTypeDTO>> GetCeremonyTypes(int userId)
        {
            var user = await this._userRepository.FindById(userId);

            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            var person = await this._personRepository.FindById(user.PersonId);

            if (person == null)
            {
                throw new UserNotFoundException(userId);
            }

            var ceremonyTypes = await this._ceremonyTypeRepository.FindByOrganisationId(person.OrganisationId);
            var result = this._mapper.Map<List<CeremonyTypeDTO>>(ceremonyTypes);

            return result;
        }
    }
}