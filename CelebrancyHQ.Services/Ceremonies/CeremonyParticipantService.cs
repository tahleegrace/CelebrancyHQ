using AutoMapper;

using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Auditing.Persons;
using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Addresses;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.PhoneNumbers;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Repository.Addresses;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.Persons;
using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.Persons;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functionality for managing ceremony participants.
    /// </summary>
    public class CeremonyParticipantService : ICeremonyParticipantService
    {
        private readonly ICeremonyHelpers _ceremonyHelpers;
        private readonly ICeremonyTypeParticipantRepository _ceremonyTypeParticipantRepository;
        private readonly ICeremonyParticipantRepository _ceremonyParticipantRepository;
        private readonly ICeremonyAccessInvitationRepository _ceremonyAccessInvitationRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPersonPhoneNumberRepository _personPhoneNumberRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICeremonyParticipantAuditingService _ceremonyParticipantAuditingService;
        private readonly IPersonService _personService;
        private readonly IPersonAuditingService _personAuditingService;
        private readonly IPersonPhoneNumberAuditingService _personPhoneNumberAuditingService;
        private readonly IPersonAddressAuditingService _personAddressAuditingService;
        private readonly IUniqueCodeGenerationService _uniqueCodeGenerationService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyParticipantService.
        /// </summary>
        /// <param name="ceremonyHelpers">The ceremony helpers.</param>
        /// <param name="ceremonyTypeParticipantRepository">The ceremony type participants repository.</param>
        /// <param name="ceremonyParticipantRepository">The ceremony participants repository.</param>
        /// <param name="ceremonyAccessInvitationRepository">The ceremony access invitations repository.</param>
        /// <param name="personRepository">The persons repository.</param>
        /// <param name="personPhoneNumberRepository">The person phone numbers repository.</param>
        /// <param name="addressRepository">The address repository.</param>
        /// <param name="ceremonyParticipantAuditingService">The ceremony participant auditing service.</param>
        /// <param name="personService">The person service.</param>
        /// <param name="personAuditingService">The person auditing service.</param>
        /// <param name="personPhoneNumberAuditingService">The person phone number auditing service.</param>
        /// <param name="personAddressAuditingService">The person address auditing service.</param>
        /// <param name="uniqueCodeGenerationService">The unique code generation service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyParticipantService(ICeremonyHelpers ceremonyHelpers, ICeremonyTypeParticipantRepository ceremonyTypeParticipantRepository,
            ICeremonyParticipantRepository ceremonyParticipantRepository, ICeremonyAccessInvitationRepository ceremonyAccessInvitationRepository,
            IPersonRepository personRepository, IPersonPhoneNumberRepository personPhoneNumberRepository, IAddressRepository addressRepository,
            ICeremonyParticipantAuditingService ceremonyParticipantAuditingService, IPersonService personService, IPersonAuditingService personAuditingService,
            IPersonPhoneNumberAuditingService personPhoneNumberAuditingService, IPersonAddressAuditingService personAddressAuditingService,
            IUniqueCodeGenerationService uniqueCodeGenerationService, IMapper mapper)
        {
            this._ceremonyHelpers = ceremonyHelpers;
            this._ceremonyTypeParticipantRepository = ceremonyTypeParticipantRepository;
            this._ceremonyParticipantRepository = ceremonyParticipantRepository;
            this._ceremonyAccessInvitationRepository = ceremonyAccessInvitationRepository;
            this._personRepository = personRepository;
            this._personPhoneNumberRepository = personPhoneNumberRepository;
            this._addressRepository = addressRepository;
            this._ceremonyParticipantAuditingService = ceremonyParticipantAuditingService;
            this._personAuditingService = personAuditingService;
            this._personService = personService;
            this._personPhoneNumberAuditingService = personPhoneNumberAuditingService;
            this._personAddressAuditingService = personAddressAuditingService;
            this._uniqueCodeGenerationService = uniqueCodeGenerationService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Gets the participants (excluding invited guests) for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The participants for the specified ceremony.</returns>
        public async Task<List<CeremonyParticipantDTO>> GetCeremonyParticipants(int ceremonyId, int currentUserId)
        {
            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to view the participants for the ceremony.
            await this._ceremonyHelpers.CheckCanViewCeremony(ceremonyId, currentUser.PersonId, CeremonyFieldNames.Participants);

            // Get the participants for the ceremony.
            var participants = await this._ceremonyParticipantRepository.GetCeremonyParticipants(ceremonyId, CeremonyTypeParticipantConstants.InvitedGuestCode);
            var personIds = participants.Select(p => p.PersonId).Distinct().ToList();
            var allPhoneNumbers = await this._personPhoneNumberRepository.GetPhoneNumbersForPersons(personIds);

            var result = participants.Select(participant =>
            {
                var dto = this._mapper.Map<CeremonyParticipantDTO>(participant);
                this._mapper.Map(participant.Person, dto);

                dto.Address = this._mapper.Map<AddressDTO>(participant.Person.Address);
                
                var participantPhoneNumbers = allPhoneNumbers.ContainsKey(participant.PersonId) ? allPhoneNumbers[participant.PersonId] : new List<PersonPhoneNumber>();
                dto.PhoneNumbers = this._mapper.Map<List<PhoneNumberDTO>>(participantPhoneNumbers);

                return dto;
            }).ToList();

            return result;
        }

        /// <summary>
        /// Creates a new ceremony participant.
        /// </summary>
        /// <param name="request">The participant.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created participant.</returns>
        public async Task<CeremonyParticipantDTO> Create(CreateCeremonyParticipantRequest request, int ceremonyId, int currentUserId)
        {
            if (request == null || String.IsNullOrWhiteSpace(request.Code))
            {
                throw new CeremonyParticipantNotProvidedException();
            }

            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to create the participant.
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
                CeremonyTypeParticipantId = ceremonyTypeParticipant.Id,
                Notes = request.Notes
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
            this._mapper.Map(newParticipant, result);
            result.PhoneNumbers = this._mapper.Map<List<PhoneNumberDTO>>(newPhoneNumbers);
            result.Address = this._mapper.Map<AddressDTO>(newAddress);
            return result;
        }


        /// <summary>
        /// Updates the details of the specified ceremony participant.
        /// </summary>
        /// <param name="participant">The participant.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task Update(UpdateCeremonyParticipantRequest participant, int currentUserId)
        {
            // Make sure the ceremony participant has been provided and has an ID.
            if ((participant == null) || (participant.Id <= 0))
            {
                throw new CeremonyParticipantNotProvidedException();
            }

            var existingParticipant = await this._ceremonyParticipantRepository.FindById(participant.Id);

            if (existingParticipant == null)
            {
                throw new CeremonyParticipantNotFoundException(participant.Id);
            }

            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(existingParticipant.CeremonyId, currentUserId);

            // Make sure the user has permissions to update the participant.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyHelpers.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Participants);

            // Generate audit events for the participant.
            var auditEvents = this._ceremonyParticipantAuditingService.GenerateAuditEvents(existingParticipant, this._mapper.Map<CeremonyParticipant>(participant));

            // Save the person.
            // TODO: Handle updating a person when they're in multiple ceremonies here or they're already registered.
            await this._personService.Update(participant, currentUserId);

            // Save the participant.
            this._mapper.Map(participant, existingParticipant);
            await this._ceremonyParticipantRepository.Update(existingParticipant);

            // Save the audit logs for the participant.
            await this._ceremonyParticipantAuditingService.SaveAuditEvents(existingParticipant, ceremony, currentUser.PersonId, auditEvents);
        }

        /// <summary>
        /// Deletes the specified ceremony participant.
        /// </summary>
        /// <param name="participantId">The ID of the participant.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task Delete(int participantId, int currentUserId)
        {
            var participant = await this._ceremonyParticipantRepository.FindById(participantId);

            if (participant == null)
            {
                throw new CeremonyParticipantNotFoundException(participantId);
            }

            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(participant.CeremonyId, currentUserId);

            // Make sure the user has permissions to delete the participant.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyHelpers.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Participants);

            // Delete the participant.
            await this._ceremonyParticipantRepository.Delete(participantId);

            var person = participant.Person;

            if (!person.Registered)
            {
                var personIsParticipantInOtherCeremonies = await this._ceremonyParticipantRepository.PersonIsParticipantInOtherCeremonies(person.Id, ceremony.Id);
                var personIsOtherParticipantInCeremony = await this._ceremonyParticipantRepository.PersonIsCeremonyParticipantOfOtherType(person.Id, ceremony.Id, 
                    participant.CeremonyTypeParticipant.Code);

                if (!personIsParticipantInOtherCeremonies && !personIsOtherParticipantInCeremony)
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