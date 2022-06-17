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
    /// A service that provides functions for managing ceremonies.
    /// </summary>
    public class CeremonyService : ICeremonyService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPersonAuditingService _personAuditingService;
        private readonly IPersonPhoneNumberAuditingService _personPhoneNumberAuditingService;
        private readonly IPersonAddressAuditingService _personAddressAuditingService;
        private readonly IAddressRepository _addressRepository;
        private readonly ICeremonyTypeParticipantRepository _ceremonyTypeParticipantRepository;
        private readonly ICeremonyTypeDateRepository _ceremonyTypeDateRepository;
        private readonly ICeremonyRepository _ceremonyRepository;
        private readonly ICeremonyPermissionRepository _ceremonyPermissionRepository;
        private readonly ICeremonyAccessInvitationRepository _ceremonyAccessInvitationRepository;
        private readonly ICeremonyVenueRepository _ceremonyVenuesRepository;
        private readonly ICeremonyParticipantRepository _ceremonyParticipantRepository;
        private readonly ICeremonyDateRepository _ceremonyDateRepository;
        private readonly IPersonPhoneNumberRepository _personPhoneNumberRepository;
        private readonly IOrganisationPhoneNumberRepository _organisationPhoneNumberRepository;
        private readonly ICeremonyAuditingService _ceremonyAuditingService;
        private readonly ICeremonyDateAuditingService _ceremonyDateAuditingService;
        private readonly ICeremonyParticipantAuditingService _ceremonyParticipantAuditingService;
        private readonly IUniqueCodeGenerationService _uniqueCodeGenerationService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyService.
        /// </summary>
        /// <param name="userRepository">The users repository.</param>
        /// <param name="personRepository">The persons repository.</param>
        /// <param name="personAuditingService">The person auditing service.</param>
        /// <param name="personPhoneNumberAuditingService">The person phone number auditing service.</param>
        /// <param name="personAddressAuditingService">The person address auditing service.</param>
        /// <param name="addressRepository">The address repository.</param>
        /// <param name="ceremonyTypeParticipantRepository">The ceremony type participants repository.</param>
        /// <param name="ceremonyTypeDateRepository">The ceremony type dates repository.</param>
        /// <param name="ceremonyRepository">The ceremonies repository.</param>
        /// <param name="ceremonyPermissionRepository">The ceremony permissions repository.</param>
        /// <param name="ceremonyAccessInvitationRepository">The ceremony access invitations repository.</param>
        /// <param name="ceremonyVenuesRepository">The ceremony venues repository.</param>
        /// <param name="ceremonyParticipantRepository">The ceremony participants repository.</param>
        /// <param name="ceremonyDateRepository">The ceremony dates repository.</param>
        /// <param name="personPhoneNumberRepository">The person phone numbers repository.</param>
        /// <param name="organisationPhoneNumberRepository">The organisation phone numbers repository.</param>
        /// <param name="ceremonyAuditingService">The ceremony auditing service.</param>
        /// <param name="ceremonyDateAuditingService">The ceremony date auditing service.</param>
        /// <param name="ceremonyParticipantAuditingService">The ceremony participant auditing service.</param>
        /// <param name="uniqueCodeGenerationService">The unique code generation service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyService(IUserRepository userRepository, IPersonRepository personRepository, IPersonAuditingService personAuditingService,
            IPersonPhoneNumberAuditingService personPhoneNumberAuditingService, IPersonAddressAuditingService personAddressAuditingService, 
            IAddressRepository addressRepository, ICeremonyTypeParticipantRepository ceremonyTypeParticipantRepository, 
            ICeremonyTypeDateRepository ceremonyTypeDateRepository, ICeremonyRepository ceremonyRepository, ICeremonyPermissionRepository ceremonyPermissionRepository, 
            ICeremonyAccessInvitationRepository ceremonyAccessInvitationRepository, ICeremonyVenueRepository ceremonyVenuesRepository, 
            ICeremonyParticipantRepository ceremonyParticipantRepository, ICeremonyDateRepository ceremonyDateRepository, 
            IPersonPhoneNumberRepository personPhoneNumberRepository, IOrganisationPhoneNumberRepository organisationPhoneNumberRepository, 
            ICeremonyAuditingService ceremonyAuditingService, ICeremonyDateAuditingService ceremonyDateAuditingService, 
            ICeremonyParticipantAuditingService ceremonyParticipantAuditingService, IUniqueCodeGenerationService uniqueCodeGenerationService, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._personRepository = personRepository;
            this._personAuditingService = personAuditingService;
            this._personPhoneNumberAuditingService = personPhoneNumberAuditingService;
            this._personAddressAuditingService = personAddressAuditingService;
            this._addressRepository = addressRepository;
            this._ceremonyTypeParticipantRepository = ceremonyTypeParticipantRepository;
            this._ceremonyTypeDateRepository = ceremonyTypeDateRepository;
            this._ceremonyRepository = ceremonyRepository;
            this._ceremonyPermissionRepository = ceremonyPermissionRepository;
            this._ceremonyAccessInvitationRepository = ceremonyAccessInvitationRepository;
            this._ceremonyVenuesRepository = ceremonyVenuesRepository;
            this._ceremonyParticipantRepository = ceremonyParticipantRepository;
            this._ceremonyDateRepository = ceremonyDateRepository;
            this._personPhoneNumberRepository = personPhoneNumberRepository;
            this._organisationPhoneNumberRepository = organisationPhoneNumberRepository;
            this._ceremonyAuditingService = ceremonyAuditingService;
            this._ceremonyDateAuditingService = ceremonyDateAuditingService;
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
            var (currentUser, ceremony) = await CheckCeremonyIsAccessible(ceremonyId, currentUserId);

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
                var permissions = await this.GetEffectivePermissionsForCeremony(ceremonyId, currentUser.PersonId, fieldName);
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
        /// Gets the dates for the ceremony with the specified ID.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The dates for the ceremony with the specified ID.</returns>
        public async Task<List<CeremonyDateDTO>> GetCeremonyDates(int ceremonyId, int currentUserId)
        {
            // TODO: Convert the dates to UTC time here based on the current user's time zone setting.
            var (currentUser, _) = await CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permission to view the dates of the ceremony.
            await CheckCanViewCeremony(ceremonyId, currentUser.PersonId, CeremonyFieldNames.Dates);

            var dates = await this._ceremonyDateRepository.GetCeremonyDates(ceremonyId);
            var dtos = this._mapper.Map<List<CeremonyDateDTO>>(dates);

            return dtos;
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

            var (currentUser, existingCeremony) = await CheckCeremonyIsAccessible(ceremony.Id, currentUserId);

            // Make sure the user has permissions to edit the ceremony.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.KeyDetails);

            // Generate audit logs for the ceremony.
            var auditEvents = this._ceremonyAuditingService.GenerateAuditEvents(existingCeremony, this._mapper.Map<Ceremony>(ceremony));

            // Save the ceremony.
            this._mapper.Map(ceremony, existingCeremony);
            await this._ceremonyRepository.Update(existingCeremony);

            // Save the audit logs for the ceremony.
            await this._ceremonyAuditingService.SaveAuditEvents(existingCeremony, currentUser.PersonId, auditEvents);
        }

        /// <summary>
        /// Creates a new date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created date.</returns>
        public async Task<CeremonyDateDTO> CreateDate(CreateCeremonyDateRequest date, int ceremonyId, int currentUserId)
        {
            // TODO: Convert the date to UTC.
            if (date == null)
            {
                throw new CeremonyDateNotProvidedException();
            }

            var (currentUser, ceremony) = await CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to add the date.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Dates);

            // Save the date.
            var otherCeremonyTypeDate = await this._ceremonyTypeDateRepository.FindByCode(CeremonyTypeDateConstants.OtherCode, ceremony.CeremonyTypeId);

            var dateToCreate = this._mapper.Map<CeremonyDate>(date);
            dateToCreate.CeremonyId = ceremonyId;
            dateToCreate.CeremonyTypeDateId = otherCeremonyTypeDate.Id;

            var newDate = await this._ceremonyDateRepository.Create(dateToCreate);

            // Generate and save audit logs for the date.
            var auditEvents = this._ceremonyDateAuditingService.GenerateAuditEvents(null, newDate);
            await this._ceremonyDateAuditingService.SaveAuditEvents(newDate, ceremony, currentUser.PersonId, auditEvents);

            return this._mapper.Map<CeremonyDateDTO>(newDate);
        }

        /// <summary>
        /// Updates the specified date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly updated date or null if the date was deleted.</returns>
        public async Task<CeremonyDateDTO?> UpdateDate(UpdateCeremonyDateRequest date, int ceremonyId, int currentUserId)
        {
            // TODO: Convert the date to UTC.
            if ((date == null) || (date.Id <= 0 || String.IsNullOrWhiteSpace(date.Code)) || (date.Code == CeremonyTypeDateConstants.OtherCode))
            {
                throw new CeremonyDateNotProvidedException();
            }

            var (currentUser, ceremony) = await CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to edit the date.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Dates);

            bool creatingNewDate;
            bool deletingDate = false;

            CeremonyDate? dateToUpdate;

            // Determine whether we are creating an new date (other than a date of type Other).
            if (date.Id != null)
            {
                dateToUpdate = await this._ceremonyDateRepository.FindById(date.Id.Value);

                if (dateToUpdate == null)
                {
                    throw new CeremonyDateNotFoundException(date.Id.Value);
                }

                creatingNewDate = false;
                deletingDate = date.Date == null;
            }
            else
            {
                dateToUpdate = await this._ceremonyDateRepository.FindByCode(ceremonyId, date.Code);

                if (dateToUpdate == null)
                {
                    if (date.Date == null)
                    {
                        return null;
                    }

                    var ceremonyTypeDate = await this._ceremonyTypeDateRepository.FindByCode(date.Code, ceremony.CeremonyTypeId);

                    if (ceremonyTypeDate == null)
                    {
                        throw new CeremonyTypeDateNotFoundWithCodeException(date.Code);
                    }

                    dateToUpdate = this._mapper.Map<CeremonyDate>(date);
                    dateToUpdate.Ceremony = ceremony;
                    dateToUpdate.CeremonyTypeDate = ceremonyTypeDate;

                    creatingNewDate = true;
                } 
                else
                {
                    creatingNewDate = false;
                    deletingDate = date.Date == null;
                }
            }

            // Generate audit events for the date.
            var newDateForAuditing = this._mapper.Map<CeremonyDate>(date);
            newDateForAuditing.CeremonyTypeDate = dateToUpdate.CeremonyTypeDate;

            var auditEvents = this._ceremonyDateAuditingService.GenerateAuditEvents(!creatingNewDate ? dateToUpdate : null, !deletingDate ? newDateForAuditing : null);

            // Save the date.
            CeremonyDate? newDate;

            if (creatingNewDate)
            {
                newDate = await this._ceremonyDateRepository.Create(dateToUpdate);
            }
            else if (deletingDate)
            {
                await this._ceremonyDateRepository.Delete(dateToUpdate.Id);
                newDate = null;
            }
            else
            {
                this._mapper.Map(date, dateToUpdate);
                newDate = await this._ceremonyDateRepository.Update(dateToUpdate);
            }

            // Save the audit logs for the date.
            await this._ceremonyDateAuditingService.SaveAuditEvents(dateToUpdate, ceremony, currentUser.PersonId, auditEvents);

            return this._mapper.Map<CeremonyDateDTO>(newDate);
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

            var (currentUser, ceremony) = await CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to edit the date.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Participants);

            // Make sure there is a ceremony type participant with the specified code.
            var ceremonyTypeParticipant = await this._ceremonyTypeParticipantRepository.FindByCode(ceremony.CeremonyTypeId, request.Code);

            if (ceremonyTypeParticipant == null)
            {
                throw new CeremonyTypeParticipantNotFoundWithCodeException(request.Code);
            }

            // Save the address of the person.
            Address? newAddress = null;

            if (request.Address != null)
            {
                var addressToCreate = this._mapper.Map<Address>(request.Address);
                newAddress = await this._addressRepository.Create(addressToCreate);
            }

            // Save the person.
            // TODO: Handle the scenario where a person already exists with the specified email address here.
            var personToCreate = this._mapper.Map<Person>(request);
            personToCreate.AddressId = newAddress?.Id;

            var newPerson = await this._personRepository.Create(personToCreate);

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

            var newPhoneNumbers = await this._personPhoneNumberRepository.Create(phoneNumbersToCreate);

            // Generate and save audit logs for the new phone numbers.
            foreach (var phoneNumber in newPhoneNumbers)
            {
                var phoneNumberAuditEvents = this._personPhoneNumberAuditingService.GenerateAuditEvents(null, phoneNumber);
                await this._personPhoneNumberAuditingService.SaveAuditEvents(phoneNumber, newPerson, currentUser.Person.Id, phoneNumberAuditEvents);
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

            // Create an access invitation for the new person.
            var invitation = new CeremonyAccessInvitation()
            {
                CeremonyId = ceremony.Id,
                PersonId = newPerson.Id,
                UniqueCode = this._uniqueCodeGenerationService.GenerateUniqueCode(CeremonyAccessInvitationConstants.UniqueCodeLength),
                Accepted = false
            };

            await this._ceremonyAccessInvitationRepository.Create(invitation);

            var result = this._mapper.Map<CeremonyParticipantDTO>(newPerson);
            result.Name = ceremonyTypeParticipant.Name;
            result.Code = ceremonyTypeParticipant.Code;
            result.PhoneNumbers = this._mapper.Map<List<PhoneNumberDTO>>(newPhoneNumbers);
            result.Address = this._mapper.Map<AddressDTO>(newAddress);
            return result;
        }

        private async Task CheckCanViewCeremony(int ceremonyId, int personId, string field)
        {
            var effectivePermissions = await GetEffectivePermissionsForCeremony(ceremonyId, personId, field);

            if (!effectivePermissions.CanView)
            {
                throw new UserCannotViewCeremonyDetailsException(ceremonyId);
            }
        }

        private async Task CheckCanEditCeremony(int ceremonyId, int personId, string field)
        {
            var effectivePermissions = await GetEffectivePermissionsForCeremony(ceremonyId, personId, field);

            if (!effectivePermissions.CanEdit)
            {
                throw new UserCannotEditCeremonyException(ceremonyId);
            }
        }

        private async Task<CeremonyPermissionDTO> GetEffectivePermissionsForCeremony(int ceremonyId, int personId, string field)
        {
            var effectivePermissions = new CeremonyPermissionDTO()
            {
                Field = field
            };

            var permissions = await this._ceremonyPermissionRepository.GetCeremonyPermissionsForPerson(ceremonyId, personId, field);

            foreach (CeremonyPermission ceremonyPermission in permissions)
            {
                if (ceremonyPermission.CanView)
                {
                    effectivePermissions.CanView = true;
                }

                if (ceremonyPermission.CanEdit)
                {
                    effectivePermissions.CanEdit = true;
                }

                if (ceremonyPermission.CanEditWithApproval)
                {
                    effectivePermissions.CanEditWithApproval = true;
                }

                if (ceremonyPermission.IsApprover)
                {
                    effectivePermissions.IsApprover = true;
                }

                if (ceremonyPermission.CanViewHistory)
                {
                    effectivePermissions.CanViewHistory = true;
                }
            }

            return effectivePermissions;
        }

        private async Task<(User user, Ceremony ceremony)> CheckCeremonyIsAccessible(int ceremonyId, int currentUserId)
        {
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

            return (user, ceremony);
        }
    }
}