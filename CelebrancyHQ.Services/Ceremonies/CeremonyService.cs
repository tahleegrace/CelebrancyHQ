using AutoMapper;

using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.Organisations;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.Organisations;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// A service that provides functions for managing ceremonies.
    /// </summary>
    public class CeremonyService : ICeremonyService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICeremonyTypeParticipantRepository _ceremonyTypeParticipantRepository;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly ICeremonyVenueRepository _ceremonyVenuesRepository;
        private readonly ICeremonyParticipantRepository _ceremonyParticipantRepository;
        private readonly IOrganisationPhoneNumberRepository _organisationPhoneNumberRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyService.
        /// </summary>
        /// <param name="userRepository">The users repository.</param>
        /// <param name="ceremonyTypeParticipantRepository">The ceremony type participants repository.</param>
        /// <param name="ceremonyRepository">The ceremonies repository.</param>
        /// <param name="ceremonyVenuesRepository">The ceremony venues repository.</param>
        /// <param name="ceremonyParticipantRepository">The ceremony participants repository.</param>
        /// <param name="organisationPhoneNumberRepository">The organisation phone numbers repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyService(IUserRepository userRepository, ICeremonyTypeParticipantRepository ceremonyTypeParticipantRepository,
            ICeremonyRepository ceremonyRepository, ICeremonyVenueRepository ceremonyVenuesRepository, ICeremonyParticipantRepository ceremonyParticipantRepository, 
            IOrganisationPhoneNumberRepository organisationPhoneNumberRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._ceremonyTypeParticipantRepository = ceremonyTypeParticipantRepository;
            this._ceremonyRepository = ceremonyRepository;
            this._ceremonyVenuesRepository = ceremonyVenuesRepository;
            this._ceremonyParticipantRepository = ceremonyParticipantRepository;
            this._organisationPhoneNumberRepository = organisationPhoneNumberRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Gets all the ceremonies where the specified user has the specified participant type between the specified dates.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="participantTypeCode">The participant type.</param>
        /// <param name="from">The from date.</param>
        /// <param name="to">The to date.</param>
        /// <returns>The ceremonies matching the specified criteria.</returns>
        public async Task<List<CeremonySummaryDTO>> GetAll(int userId, string? participantTypeCode, DateTime? from, DateTime? to)
        {
            var user = await this._userRepository.FindById(userId);

            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            // TODO: Convert the dates to UTC time here based on the current user's time zone setting.
            var participantTypeIds = !String.IsNullOrEmpty(participantTypeCode) ? await this._ceremonyTypeParticipantRepository.FindIdsByCode(participantTypeCode) : new List<int>();
            var ceremonies = await this._ceremonyRepository.GetAll(user.PersonId, participantTypeIds, from, to);
            var ceremonyIds = ceremonies.Select(c => c.Id).ToList();
            var ceremonyVenues = await this._ceremonyVenuesRepository.GetPrimaryVenuesForCeremonies(ceremonyIds);

            var result = ceremonies.Select(ceremony => 
            {
                var venue = ceremonyVenues.ContainsKey(ceremony.Id) ? ceremonyVenues[ceremony.Id] : null;
                var dto = this._mapper.Map<CeremonySummaryDTO>(ceremony);

                dto.PrimaryVenue = this._mapper.Map<OrganisationKeyDetailsDTO>(venue);

                return dto;
            }).ToList();

            return result;
        }

        /// <summary>
        /// Gets the key details for the ceremony with the specified ID.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The key details for the ceremony with the specified ID.</returns>
        public async Task<CeremonyKeyDetailsDTO?> GetCeremonyKeyDetails(int ceremonyId, int currentUserId)
        {
            // TODO: Convert the dates to UTC time here based on the current user's time zone setting.
            var user = await this._userRepository.FindById(currentUserId);

            if (user == null)
            {
                throw new UserNotFoundException(currentUserId);
            }

            var ceremony = await this._ceremonyRepository.FindById(ceremonyId);

            if (ceremony == null)
            {
                throw new CeremonyNotFoundException(ceremonyId);
            }

            // Make sure the current user is a participant in the ceremony.
            var canAccessCeremony = await this._ceremonyParticipantRepository.PersonIsCeremonyParticipant(user.PersonId, ceremonyId);

            if (!canAccessCeremony)
            {
                throw new UserNotCeremonyParticipantException(ceremonyId);
            }

            // Get the participants in the ceremony.
            // TODO: Return the participant phone numbers here.
            var participants = await this._ceremonyParticipantRepository.GetCeremonyParticipants(ceremonyId);
            var participantDTOs = participants.Select(participant =>
            {
                var dto = this._mapper.Map<CeremonyParticipantDTO>(participant.Person);
                this._mapper.Map(participant, dto);

                return dto;
            }).ToList();

            // Get the primary venue for the ceremony.
            var primaryVenue = await this._ceremonyVenuesRepository.GetPrimaryVenueForCeremony(ceremonyId);

            // Return the ceremony details.
            var dto = this._mapper.Map<CeremonyKeyDetailsDTO>(ceremony);
            dto.PrimaryVenue = this._mapper.Map<OrganisationKeyDetailsDTO>(primaryVenue);

            if (primaryVenue != null)
            {
                var primaryVenuePhone = await this._organisationPhoneNumberRepository.GetOrganisationPrimaryPhoneNumber(primaryVenue.Id);
                dto.PrimaryVenue.PrimaryPhoneNumber = primaryVenuePhone?.PhoneNumber;
            }

            dto.Participants = participantDTOs;

            return dto;
        }
    }
}