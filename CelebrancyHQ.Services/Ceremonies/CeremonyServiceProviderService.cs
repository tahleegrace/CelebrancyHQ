using AutoMapper;

using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Auditing.Organisations;
using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Constants.Organisations;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Addresses;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.PhoneNumbers;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.Exceptions.CeremonyTypes;
using CelebrancyHQ.Repository.Addresses;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.CeremonyTypes;
using CelebrancyHQ.Repository.Organisations;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functionality for managing ceremony service providers.
    /// </summary>
    public class CeremonyServiceProviderService : ICeremonyServiceProviderService
    {
        private readonly ICeremonyPermissionService _ceremonyPermissionService;
        private readonly ICeremonyTypeServiceProviderRepository _ceremonyTypeServiceProviderRepository;
        private readonly ICeremonyServiceProviderRepository _ceremonyServiceProviderRepository;
        private readonly IOrganisationRepository _organisationRepository;
        private readonly IOrganisationPhoneNumberRepository _organisationPhoneNumberRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICeremonyServiceProviderAuditingService _ceremonyServiceProviderAuditingService;
        private readonly IOrganisationAuditingService _organisationAuditingService;
        private readonly IOrganisationAddressAuditingService _organisationAddressAuditingService;
        private readonly IOrganisationPhoneNumberAuditingService _organisationPhoneNumberAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyServiceProviderService.
        /// </summary>
        /// <param name="ceremonyPermissionService">The ceremony permission service.</param>
        /// <param name="ceremonyTypeServiceProviderRepository">The ceremony type service provider repository.</param>
        /// <param name="ceremonyServiceProviderRepository">The ceremony service provider repository.</param>
        /// <param name="organisationRepository">The organisation repository.</param>
        /// <param name="organisationPhoneNumberRepository">The organisation phone numbers repository.</param>
        /// <param name="addressRepository">The address repository.</param>
        /// <param name="ceremonyServiceProviderAuditingService">The ceremony service provider auditing service.</param>
        /// <param name="organisationAddressAuditingService">The organisation address auditing service.</param>
        /// <param name="organisationPhoneNumberAuditingService">The organisation phone number auditing service.</param>
        /// <param name="organisationAuditingService">The organisation auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyServiceProviderService(ICeremonyPermissionService ceremonyPermissionService, ICeremonyTypeServiceProviderRepository ceremonyTypeServiceProviderRepository,
            ICeremonyServiceProviderRepository ceremonyServiceProviderRepository, IOrganisationRepository organisationRepository,
            IOrganisationPhoneNumberRepository organisationPhoneNumberRepository, IAddressRepository addressRepository, 
            ICeremonyServiceProviderAuditingService ceremonyServiceProviderAuditingService, IOrganisationAuditingService organisationAuditingService, 
            IOrganisationAddressAuditingService organisationAddressAuditingService, IOrganisationPhoneNumberAuditingService organisationPhoneNumberAuditingService,
            IMapper mapper)
        {
            this._ceremonyPermissionService = ceremonyPermissionService;
            this._ceremonyTypeServiceProviderRepository = ceremonyTypeServiceProviderRepository;
            this._ceremonyServiceProviderRepository = ceremonyServiceProviderRepository;
            this._organisationRepository = organisationRepository;
            this._organisationPhoneNumberRepository = organisationPhoneNumberRepository;
            this._addressRepository = addressRepository;
            this._ceremonyServiceProviderAuditingService = ceremonyServiceProviderAuditingService;
            this._organisationAuditingService = organisationAuditingService;
            this._organisationAddressAuditingService = organisationAddressAuditingService;
            this._organisationPhoneNumberAuditingService = organisationPhoneNumberAuditingService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Creates a new ceremony service provider.
        /// </summary>
        /// <param name="request">The service provider.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created service provider.</returns>
        public async Task<CeremonyServiceProviderDTO> Create(CreateCeremonyServiceProviderRequest request, int ceremonyId, int currentUserId)
        {
            if (request == null || String.IsNullOrWhiteSpace(request.Code))
            {
                throw new CeremonyServiceProviderNotProvidedException();
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to create the service provider.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.ServiceProviders);

            // Make sure there is a ceremony type service provider with the specified code.
            var ceremonyTypeServiceProvider = await this._ceremonyTypeServiceProviderRepository.FindByCode(ceremony.CeremonyTypeId, request.Code);

            if (ceremonyTypeServiceProvider == null)
            {
                throw new CeremonyTypeServiceProviderNotFoundWithCodeException(request.Code);
            }

            Organisation? newOrganisation = await this._organisationRepository.FindByName(request.Name);
            Address? newAddress = null;
            List<OrganisationPhoneNumber> newPhoneNumbers;

            if (newOrganisation == null)
            {
                // Save the address of the organisation.
                if (request.Address != null)
                {
                    var addressToCreate = this._mapper.Map<Address>(request.Address);
                    newAddress = await this._addressRepository.Create(addressToCreate);
                }

                // Save the organisation.
                var organisationToCreate = this._mapper.Map<Organisation>(request);
                organisationToCreate.Type = OrganisationConstants.ServiceProviderOrganisationType;
                organisationToCreate.AddressId = newAddress.Id;

                newOrganisation = await this._organisationRepository.Create(organisationToCreate);

                // Generate and save audit logs for the new organisation.
                var organiationAuditEvents = this._organisationAuditingService.GenerateAuditEvents(null, newOrganisation);
                await this._organisationAuditingService.SaveAuditEvents(newOrganisation, currentUser.PersonId, organiationAuditEvents);

                // Save the phone numbers for the organisation.
                var phoneNumbersToCreate = this._mapper.Map<List<OrganisationPhoneNumber>>(request.PhoneNumbers);

                foreach (var phoneNumber in phoneNumbersToCreate)
                {
                    phoneNumber.OrganisationId = newOrganisation.Id;
                }

                newPhoneNumbers = await this._organisationPhoneNumberRepository.Create(phoneNumbersToCreate);

                // Generate and save audit logs for the new phone numbers.
                foreach (var phoneNumber in newPhoneNumbers)
                {
                    var phoneNumberAuditEvents = this._organisationPhoneNumberAuditingService.GenerateAuditEvents(null, phoneNumber);
                    await this._organisationPhoneNumberAuditingService.SaveAuditEvents(phoneNumber, newOrganisation, currentUser.Person.Id, phoneNumberAuditEvents);
                }

                // Generate and save audit logs for the new organisation's address.
                if (newAddress != null)
                {
                    var addressAuditEvents = this._organisationAddressAuditingService.GenerateAuditEvents(null, newAddress);
                    await this._organisationAuditingService.SaveAuditEvents(newOrganisation, currentUser.PersonId, addressAuditEvents);
                }
            }
            else
            {
                // Make sure the service provider isn't already a ceremony service provider.
                var isExistingServiceProvider = await this._ceremonyServiceProviderRepository.OrganisationIsCeremonyServiceProvider(newOrganisation.Id, ceremonyId, request.Code);

                if (isExistingServiceProvider)
                {
                    throw new OrganisationAlreadyCeremonyServiceProviderException(ceremonyId, request.Code);
                }

                // Get the phone numbers and address for the organisation.
                newPhoneNumbers = await this._organisationPhoneNumberRepository.GetPhoneNumbersForOrganisation(newOrganisation.Id);
                newAddress = newOrganisation.Address;
            }

            // Save the ceremony service provider.
            var serviceProviderToCreate = new CeremonyServiceProvider()
            {
                CeremonyId = ceremony.Id,
                OrganisationId = newOrganisation.Id,
                CeremonyTypeServiceProviderId = ceremonyTypeServiceProvider.Id,
                Notes = request.Notes
            };

            var newServiceProvider = await this._ceremonyServiceProviderRepository.Create(serviceProviderToCreate);

            // Generate and save audit logs for the service provider.
            var serviceProviderAuditEvents = this._ceremonyServiceProviderAuditingService.GenerateAuditEvents(null, newServiceProvider);
            await this._ceremonyServiceProviderAuditingService.SaveAuditEvents(newServiceProvider, ceremony, currentUser.PersonId, serviceProviderAuditEvents);

            var result = this._mapper.Map<CeremonyServiceProviderDTO>(newServiceProvider);
            result.Address = this._mapper.Map<AddressDTO>(newAddress);
            result.PhoneNumbers = this._mapper.Map<List<PhoneNumberDTO>>(newPhoneNumbers);
            return result;
        }

        /// <summary>
        /// Deletes the specified ceremony service provider.
        /// </summary>
        /// <param name="serviceProviderId">The ID of the service provider.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task Delete(int serviceProviderId, int currentUserId)
        {
            var serviceProvider = await this._ceremonyServiceProviderRepository.FindById(serviceProviderId);

            if (serviceProvider == null)
            {
                throw new CeremonyServiceProviderNotFoundException(serviceProviderId);
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(serviceProvider.CeremonyId, currentUserId);

            // Make sure the user has permissions to delete the service provider.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.ServiceProviders);

            // Delete the service provider.
            await this._ceremonyServiceProviderRepository.Delete(serviceProviderId);

            var organisation = serviceProvider.Organisation;

            var organisationIsOtherServiceProviderForCeremony =
                await this._ceremonyServiceProviderRepository.OrganisationIsCeremonyServiceProviderOfOtherType(organisation.Id, ceremony.Id,
                serviceProvider.CeremonyTypeServiceProvider.Code);

            var organisationIsServiceProviderInOtherCeremonies = 
                await this._ceremonyServiceProviderRepository.OrganisationIsServiceProviderForOtherCeremonies(organisation.Id, ceremony.Id);

            if (!organisationIsServiceProviderInOtherCeremonies && !organisationIsOtherServiceProviderForCeremony)
            {
                await this._organisationRepository.Delete(organisation.Id);

                // Generate and save audit logs for the organisation.
                var organisationAuditEvents = this._organisationAuditingService.GenerateAuditEvents(organisation, null);
                await this._organisationAuditingService.SaveAuditEvents(organisation, currentUser.PersonId, organisationAuditEvents);
            }

            // Generate and save audit logs for the service provider.
            var serviceProviderAuditEvents = this._ceremonyServiceProviderAuditingService.GenerateAuditEvents(serviceProvider, null);
            await this._ceremonyServiceProviderAuditingService.SaveAuditEvents(serviceProvider, ceremony, currentUser.PersonId, serviceProviderAuditEvents);
        }
    }
}