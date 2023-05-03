using AutoMapper;
using CelebrancyHQ.Models.DTOs.CeremonyTypes;
using CelebrancyHQ.Models.Exceptions.CeremonyTypes;
using CelebrancyHQ.Repository.CeremonyTypes;

namespace CelebrancyHQ.Services.CeremonyTypes
{
    /// <summary>
    /// Provides functions for managing ceremony type participants.
    /// </summary>
    public class CeremonyTypeParticipantService : ICeremonyTypeParticipantService
    {
        private readonly ICeremonyTypeRepository _ceremonyTypeRepository;
        private readonly ICeremonyTypeParticipantRepository _ceremonyTypeParticipantRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyTypeParticipantService.
        /// </summary>
        /// <param name="ceremonyTypeRepository">The ceremony type repository.</param>
        /// <param name="ceremonyTypeParticipantRepository">The ceremony type participant repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyTypeParticipantService(ICeremonyTypeRepository ceremonyTypeRepository, ICeremonyTypeParticipantRepository ceremonyTypeParticipantRepository,
            IMapper mapper)
        {
            _ceremonyTypeRepository = ceremonyTypeRepository;
            _ceremonyTypeParticipantRepository = ceremonyTypeParticipantRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the ceremony type participants for the specified ceremony type.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="codeToExclude">The code of ceremony type participants to exclude.</param>
        /// <returns>The ceremony type participants for the specified ceremony type.</returns>
        public async Task<List<CeremonyTypeParticipantDTO>> GetCeremonyTypeParticipants(int ceremonyTypeId, string? codeToExclude)
        {
            var ceremonyType = await _ceremonyTypeRepository.FindById(ceremonyTypeId);

            if (ceremonyType == null)
            {
                throw new CeremonyTypeNotFoundException(ceremonyTypeId);
            }

            var typeParticipants = await _ceremonyTypeParticipantRepository.FindByCeremonyTypeId(ceremonyTypeId, codeToExclude);
            var result = _mapper.Map<List<CeremonyTypeParticipantDTO>>(typeParticipants);

            return result;
        }
    }
}