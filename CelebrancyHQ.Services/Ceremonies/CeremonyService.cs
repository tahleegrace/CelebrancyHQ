using AutoMapper;

using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.Organisations;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.Organisations;
using CelebrancyHQ.Repository.Persons;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functions for managing ceremonies.
    /// </summary>
    public class CeremonyService : ICeremonyService
    {
        private readonly ICeremonyHelpers _ceremonyHelpers;
        private readonly IUserRepository _userRepository;
        private readonly ICeremonyTypeParticipantRepository _ceremonyTypeParticipantRepository;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly ICeremonyVenueRepository _ceremonyVenuesRepository;
        private readonly ICeremonyParticipantRepository _ceremonyParticipantRepository;
        private readonly IPersonPhoneNumberRepository _personPhoneNumberRepository;
        private readonly IOrganisationPhoneNumberRepository _organisationPhoneNumberRepository;
        private readonly ICeremonyAuditingService _ceremonyAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyService.
        /// </summary>
        /// <param name="ceremonyHelpers">The ceremony helpers.</param>
        /// <param name="userRepository">The users repository.</param>
        /// <param name="ceremonyTypeParticipantRepository">The ceremony type participants repository.</param>
        /// <param name="ceremonyRepository">The ceremonies repository.</param>
        /// <param name="ceremonyVenuesRepository">The ceremony venues repository.</param>
        /// <param name="ceremonyParticipantRepository">The ceremony participants repository.</param>
        /// <param name="personPhoneNumberRepository">The person phone numbers repository.</param>
        /// <param name="organisationPhoneNumberRepository">The organisation phone numbers repository.</param>
        /// <param name="ceremonyAuditingService">The ceremony auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyService(ICeremonyHelpers ceremonyHelpers, IUserRepository userRepository,
            ICeremonyTypeParticipantRepository ceremonyTypeParticipantRepository, ICeremonyRepository ceremonyRepository, 
            ICeremonyVenueRepository ceremonyVenuesRepository, ICeremonyParticipantRepository ceremonyParticipantRepository,
            IPersonPhoneNumberRepository personPhoneNumberRepository, IOrganisationPhoneNumberRepository organisationPhoneNumberRepository, 
            ICeremonyAuditingService ceremonyAuditingService, IMapper mapper)
        {
            this._ceremonyHelpers = ceremonyHelpers;
            this._userRepository = userRepository;
            this._ceremonyTypeParticipantRepository = ceremonyTypeParticipantRepository;
            this._ceremonyRepository = ceremonyRepository;
            this._ceremonyVenuesRepository = ceremonyVenuesRepository;
            this._ceremonyParticipantRepository = ceremonyParticipantRepository;
            this._personPhoneNumberRepository = personPhoneNumberRepository;
            this._organisationPhoneNumberRepository = organisationPhoneNumberRepository;
            this._ceremonyAuditingService = ceremonyAuditingService;
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
        public async Task<CeremonyKeyDetailsDTO> GetCeremonyKeyDetails(int ceremonyId, int currentUserId)
        {
            // TODO: Convert the dates to UTC time here based on the current user's time zone setting.
            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Get the participants in the ceremony.
            var participants = await this._ceremonyParticipantRepository.GetCeremonyParticipants(ceremonyId, CeremonyTypeParticipantConstants.InvitedGuestCode);
            var participantPhoneNumbers = await this._personPhoneNumberRepository.GetPrimaryPhoneNumbersForCeremonyParticipants(ceremonyId);

            var participantDTOs = participants.Select(participant =>
            {
                var dto = this._mapper.Map<CeremonyParticipantDTO>(participant.Person);
                var phoneNumber = participantPhoneNumbers.ContainsKey(participant.PersonId) ? participantPhoneNumbers[participant.PersonId] : null;

                this._mapper.Map(participant, dto);
                dto.PrimaryPhoneNumber = phoneNumber?.PhoneNumber;

                return dto;
            }).ToList();

            // Get the primary venue for the ceremony.
            var primaryVenue = await this._ceremonyVenuesRepository.GetPrimaryVenueForCeremony(ceremonyId);

            // Get the effective permissions for the ceremony.
            var effectivePermissions = new List<CeremonyPermissionDTO>();

            foreach (string fieldName in CeremonyFieldNames.FieldNames)
            {
                var permissions = await this._ceremonyHelpers.GetEffectivePermissionsForCeremony(ceremonyId, currentUser.PersonId, fieldName);
                effectivePermissions.Add(permissions);
            }

            // Return the ceremony details.
            var dto = this._mapper.Map<CeremonyKeyDetailsDTO>(ceremony);
            dto.PrimaryVenue = this._mapper.Map<OrganisationKeyDetailsDTO>(primaryVenue);

            if (primaryVenue != null)
            {
                var primaryVenuePhone = await this._organisationPhoneNumberRepository.GetOrganisationPrimaryPhoneNumber(primaryVenue.Id);
                dto.PrimaryVenue.PrimaryPhoneNumber = primaryVenuePhone?.PhoneNumber;
            }

            dto.Participants = participantDTOs;
            dto.EffectivePermissions = effectivePermissions;

            return dto;
        }

        /// <summary>
        /// Updates the details of the specified ceremony.
        /// </summary>
        /// <param name="ceremony">The ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task Update(UpdateCeremonyRequest ceremony, int currentUserId)
        {
            // Make sure the ceremony has been provided and has an ID.
            if ((ceremony == null) || (ceremony.Id <= 0))
            {
                throw new CeremonyNotProvidedException();
            }

            var (currentUser, existingCeremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(ceremony.Id, currentUserId);

            // Make sure the user has permissions to edit the ceremony.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyHelpers.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.KeyDetails);

            // Generate audit logs for the ceremony.
            var auditEvents = this._ceremonyAuditingService.GenerateAuditEvents(existingCeremony, this._mapper.Map<Ceremony>(ceremony));

            // Save the ceremony.
            this._mapper.Map(ceremony, existingCeremony);
            await this._ceremonyRepository.Update(existingCeremony);

            // Save the audit logs for the ceremony.
            await this._ceremonyAuditingService.SaveAuditEvents(existingCeremony, currentUser.PersonId, auditEvents);
        }
    }
}