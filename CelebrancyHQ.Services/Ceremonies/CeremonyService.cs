using AutoMapper;

using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Auditing.Persons;
using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Addresses;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.Organisations;
using CelebrancyHQ.Models.DTOs.PhoneNumbers;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Repository.Addresses;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.Organisations;
using CelebrancyHQ.Repository.Persons;
using CelebrancyHQ.Repository.Users;
using CelebrancyHQ.Services.Authentication;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functions for managing ceremonies.
    /// </summary>
    public class CeremonyService : ICeremonyService
    {
        private readonly ICeremonyHelpers _ceremonyHelpers;
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPersonAuditingService _personAuditingService;
        private readonly IPersonPhoneNumberAuditingService _personPhoneNumberAuditingService;
        private readonly IPersonAddressAuditingService _personAddressAuditingService;
        private readonly IAddressRepository _addressRepository;
        private readonly ICeremonyTypeParticipantRepository _ceremonyTypeParticipantRepository;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly ICeremonyPermissionRepository _ceremonyPermissionRepository;
        private readonly ICeremonyAccessInvitationRepository _ceremonyAccessInvitationRepository;
        private readonly ICeremonyVenueRepository _ceremonyVenuesRepository;
        private readonly ICeremonyParticipantRepository _ceremonyParticipantRepository;
        private readonly IPersonPhoneNumberRepository _personPhoneNumberRepository;
        private readonly IOrganisationPhoneNumberRepository _organisationPhoneNumberRepository;
        private readonly ICeremonyAuditingService _ceremonyAuditingService;
        private readonly ICeremonyParticipantAuditingService _ceremonyParticipantAuditingService;
        private readonly IUniqueCodeGenerationService _uniqueCodeGenerationService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyService.
        /// </summary>
        /// <param name="ceremonyHelpers">The ceremony helpers.</param>
        /// <param name="userRepository">The users repository.</param>
        /// <param name="personRepository">The persons repository.</param>
        /// <param name="personAuditingService">The person auditing service.</param>
        /// <param name="personPhoneNumberAuditingService">The person phone number auditing service.</param>
        /// <param name="personAddressAuditingService">The person address auditing service.</param>
        /// <param name="addressRepository">The address repository.</param>
        /// <param name="ceremonyTypeParticipantRepository">The ceremony type participants repository.</param>
        /// <param name="ceremonyRepository">The ceremonies repository.</param>
        /// <param name="ceremonyPermissionRepository">The ceremony permissions repository.</param>
        /// <param name="ceremonyAccessInvitationRepository">The ceremony access invitations repository.</param>
        /// <param name="ceremonyVenuesRepository">The ceremony venues repository.</param>
        /// <param name="ceremonyParticipantRepository">The ceremony participants repository.</param>
        /// <param name="ceremonyDateRepository">The ceremony dates repository.</param>
        /// <param name="personPhoneNumberRepository">The person phone numbers repository.</param>
        /// <param name="organisationPhoneNumberRepository">The organisation phone numbers repository.</param>
        /// <param name="ceremonyAuditingService">The ceremony auditing service.</param>
        /// <param name="ceremonyParticipantAuditingService">The ceremony participant auditing service.</param>
        /// <param name="uniqueCodeGenerationService">The unique code generation service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyService(ICeremonyHelpers ceremonyHelpers, IUserRepository userRepository, IPersonRepository personRepository, IPersonAuditingService personAuditingService,
            IPersonPhoneNumberAuditingService personPhoneNumberAuditingService, IPersonAddressAuditingService personAddressAuditingService, 
            IAddressRepository addressRepository, ICeremonyTypeParticipantRepository ceremonyTypeParticipantRepository, 
            ICeremonyRepository ceremonyRepository, ICeremonyPermissionRepository ceremonyPermissionRepository, 
            ICeremonyAccessInvitationRepository ceremonyAccessInvitationRepository, ICeremonyVenueRepository ceremonyVenuesRepository, 
            ICeremonyParticipantRepository ceremonyParticipantRepository,
            IPersonPhoneNumberRepository personPhoneNumberRepository, IOrganisationPhoneNumberRepository organisationPhoneNumberRepository, 
            ICeremonyAuditingService ceremonyAuditingService, 
            ICeremonyParticipantAuditingService ceremonyParticipantAuditingService, IUniqueCodeGenerationService uniqueCodeGenerationService, IMapper mapper)
        {
            this._ceremonyHelpers = ceremonyHelpers;
            this._userRepository = userRepository;
            this._personRepository = personRepository;
            this._personAuditingService = personAuditingService;
            this._personPhoneNumberAuditingService = personPhoneNumberAuditingService;
            this._personAddressAuditingService = personAddressAuditingService;
            this._addressRepository = addressRepository;
            this._ceremonyTypeParticipantRepository = ceremonyTypeParticipantRepository;
            this._ceremonyRepository = ceremonyRepository;
            this._ceremonyPermissionRepository = ceremonyPermissionRepository;
            this._ceremonyAccessInvitationRepository = ceremonyAccessInvitationRepository;
            this._ceremonyVenuesRepository = ceremonyVenuesRepository;
            this._ceremonyParticipantRepository = ceremonyParticipantRepository;
            this._personPhoneNumberRepository = personPhoneNumberRepository;
            this._organisationPhoneNumberRepository = organisationPhoneNumberRepository;
            this._ceremonyAuditingService = ceremonyAuditingService;
            this._ceremonyParticipantAuditingService = ceremonyParticipantAuditingService;
            this._uniqueCodeGenerationService = uniqueCodeGenerationService;
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
            // TODO: Don't show invited guests here.
            var participants = await this._ceremonyParticipantRepository.GetCeremonyParticipants(ceremonyId);
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

        /// <summary>
        /// Creates a new ceremony participant.
        /// </summary>
        /// <param name="request">The participant.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created participant.</returns>
        public async Task<CeremonyParticipantDTO> CreateParticipant(CreateCeremonyParticipantRequest request, int ceremonyId, int currentUserId)
        {
            if (request == null || String.IsNullOrWhiteSpace(request.Code))
            {
                throw new CeremonyParticipantNotProvidedException();
            }

            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to edit the date.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyHelpers.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Participants);

            // Make sure there is a ceremony type participant with the specified code.
            var ceremonyTypeParticipant = await this._ceremonyTypeParticipantRepository.FindByCode(ceremony.CeremonyTypeId, request.Code);

            if (ceremonyTypeParticipant == null)
            {
                throw new CeremonyTypeParticipantNotFoundWithCodeException(request.Code);
            }

            // Check to see whether we already have a person with the specified email address. If so, add this person
            // as a participant instead of creating a new person. Do not update the details of this person.
            Person? newPerson = await this._personRepository.FindByEmailAddress(request.EmailAddress);
            List<PersonPhoneNumber> newPhoneNumbers;
            Address? newAddress = null;

            if (newPerson == null)
            {
                // Save the address of the person.
                if (request.Address != null)
                {
                    var addressToCreate = this._mapper.Map<Address>(request.Address);
                    newAddress = await this._addressRepository.Create(addressToCreate);
                }

                // Save the person.
                var personToCreate = this._mapper.Map<Person>(request);
                personToCreate.AddressId = newAddress?.Id;

                newPerson = await this._personRepository.Create(personToCreate);

                // Generate and save audit logs for the new person.
                var personAuditEvents = this._personAuditingService.GenerateAuditEvents(null, newPerson);
                await this._personAuditingService.SaveAuditEvents(newPerson, currentUser.PersonId, personAuditEvents);

                // Generate and save audit logs for the new person's address.
                if (newAddress != null)
                {
                    var addressAuditEvents = this._personAddressAuditingService.GenerateAuditEvents(null, newAddress);
                    await this._personAuditingService.SaveAuditEvents(newPerson, currentUser.PersonId, addressAuditEvents);
                }

                // Save the phone numbers for the person.
                var phoneNumbersToCreate = this._mapper.Map<List<PersonPhoneNumber>>(request.PhoneNumbers);

                foreach (var phoneNumber in phoneNumbersToCreate)
                {
                    phoneNumber.PersonId = newPerson.Id;
                }

                newPhoneNumbers = await this._personPhoneNumberRepository.Create(phoneNumbersToCreate);

                // Generate and save audit logs for the new phone numbers.
                foreach (var phoneNumber in newPhoneNumbers)
                {
                    var phoneNumberAuditEvents = this._personPhoneNumberAuditingService.GenerateAuditEvents(null, phoneNumber);
                    await this._personPhoneNumberAuditingService.SaveAuditEvents(phoneNumber, newPerson, currentUser.Person.Id, phoneNumberAuditEvents);
                }
            }
            else
            {
                // Make sure the user isn't already a ceremony participant.
                var isExistingParticipant = await this._ceremonyParticipantRepository.PersonIsCeremonyParticipant(newPerson.Id, ceremonyId, request.Code);

                if (isExistingParticipant)
                {
                    throw new PersonAlreadyCeremonyParticipantException(ceremonyId, request.Code);
                }

                // Get the phone numbers and address for the person.
                newPhoneNumbers = await this._personPhoneNumberRepository.GetPhoneNumbersForPerson(newPerson.Id);
                newAddress = newPerson.Address;
            }

            // Save the ceremony participant.
            var participantToCreate = new CeremonyParticipant()
            {
                CeremonyId = ceremony.Id,
                PersonId = newPerson.Id,
                CeremonyTypeParticipantId = ceremonyTypeParticipant.Id
            };

            var newParticipant = await this._ceremonyParticipantRepository.Create(participantToCreate);

            // Generate and save audit logs for the participant.
            var participantAuditEvents = this._ceremonyParticipantAuditingService.GenerateAuditEvents(null, newParticipant);
            await this._ceremonyParticipantAuditingService.SaveAuditEvents(newParticipant, ceremony, currentUser.PersonId, participantAuditEvents);

            // Create an access invitation for the new person if one hasn't already been created.
            var hasAccessInvitation = await this._ceremonyAccessInvitationRepository.PersonHasCeremonyAccessInvitation(newPerson.Id, ceremonyId); ;

            if (!hasAccessInvitation)
            {
                var invitation = new CeremonyAccessInvitation()
                {
                    CeremonyId = ceremony.Id,
                    PersonId = newPerson.Id,
                    UniqueCode = this._uniqueCodeGenerationService.GenerateUniqueCode(CeremonyAccessInvitationConstants.UniqueCodeLength),
                    Accepted = false
                };

                await this._ceremonyAccessInvitationRepository.Create(invitation);
            }

            var result = this._mapper.Map<CeremonyParticipantDTO>(newPerson);
            result.Name = ceremonyTypeParticipant.Name;
            result.Code = ceremonyTypeParticipant.Code;
            result.PhoneNumbers = this._mapper.Map<List<PhoneNumberDTO>>(newPhoneNumbers);
            result.Address = this._mapper.Map<AddressDTO>(newAddress);
            return result;
        }

        /// <summary>
        /// Deletes the specified ceremony participant.
        /// </summary>
        /// <param name="participantId">The ID of the participant.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task DeleteParticipant(int participantId, int currentUserId)
        {
            var participant = await this._ceremonyParticipantRepository.FindById(participantId);

            if (participant == null)
            {
                throw new CeremonyParticipantNotFoundException(participantId);
            }

            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(participant.CeremonyId, currentUserId);

            // Make sure the user has permissions to edit the date.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyHelpers.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Participants);

            // Delete the participant.
            await this._ceremonyParticipantRepository.Delete(participantId);

            var person = participant.Person;

            if (!person.Registered)
            {
                var userIsParticipantInOtherCeremonies = await this._ceremonyParticipantRepository.PersonIsParticipantInOtherCeremonies(person.Id, ceremony.Id);

                if (!userIsParticipantInOtherCeremonies)
                {
                    await this._personRepository.Delete(person.Id);

                    // Generate and save audit logs for the person.
                    var personAuditEvents = this._personAuditingService.GenerateAuditEvents(person, null);
                    await this._personAuditingService.SaveAuditEvents(person, currentUser.PersonId, personAuditEvents);
                }
            }

            // Generate and save audit logs for the participant.
            var participantAuditEvents = this._ceremonyParticipantAuditingService.GenerateAuditEvents(participant, null);
            await this._ceremonyParticipantAuditingService.SaveAuditEvents(participant, ceremony, currentUser.PersonId, participantAuditEvents);
        }
    }
}