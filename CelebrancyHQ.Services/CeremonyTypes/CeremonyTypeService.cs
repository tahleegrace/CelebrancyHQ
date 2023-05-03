using AutoMapper;

using CelebrancyHQ.Models.DTOs.CeremonyTypes;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Repository.CeremonyTypes;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Services.CeremonyTypes
{
    /// <summary>
    /// Provides functions for managing the types of ceremonies that can be offered.
    /// </summary>
    public class CeremonyTypeService : ICeremonyTypeService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICeremonyTypeRepository _ceremonyTypeRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyTypeService.
        /// </summary>
        /// <param name="userRepository">The users repository.</param>
        /// <param name="ceremonyTypeRepository">The ceremony types repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyTypeService(IUserRepository userRepository, ICeremonyTypeRepository ceremonyTypeRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _ceremonyTypeRepository = ceremonyTypeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the types of ceremonies the specified user can offer.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The types of ceremonies the user can offer.</returns>
        public async Task<List<CeremonyTypeDTO>> GetCeremonyTypes(int userId)
        {
            var user = await _userRepository.FindById(userId);

            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            var ceremonyTypes = await _ceremonyTypeRepository.FindByOrganisationId(user.Person.OrganisationId);
            var result = _mapper.Map<List<CeremonyTypeDTO>>(ceremonyTypes);

            return result;
        }
    }
}