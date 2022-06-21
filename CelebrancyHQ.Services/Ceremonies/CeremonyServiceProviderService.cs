using AutoMapper;

using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Auditing.Organisations;
using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Constants.Organisations;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.Organisations;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functionality for managing ceremony service providers.
    /// </summary>
    public class CeremonyServiceProviderService : ICeremonyServiceProviderService
    {
        private readonly ICeremonyHelpers _ceremonyHelpers;
        private readonly ICeremonyTypeServiceProviderRepository _ceremonyTypeServiceProviderRepository;
        private readonly ICeremonyServiceProviderRepository _ceremonyServiceProviderRepository;
        private readonly IOrganisationRepository _organisationRepository;
        private readonly ICeremonyServiceProviderAuditingService _ceremonyServiceProviderAuditingService;
        private readonly IOrganisationAuditingService _organisationAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyServiceProviderService.
        /// </summary>
        /// <param name="ceremonyHelpers">The ceremony helpers.</param>
        /// <param name="ceremonyTypeServiceProviderRepository">The ceremony type service provider repository.</param>
        /// <param name="ceremonyServiceProviderRepository">The ceremony service provider repository.</param>
        /// <param name="organisationRepository">The organisation repository.</param>
        /// <param name="ceremonyServiceProviderAuditingService">The ceremony service provider auditing service.</param>
        /// <param name="organisationAuditingService">The organisation auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyServiceProviderService(ICeremonyHelpers ceremonyHelpers, ICeremonyTypeServiceProviderRepository ceremonyTypeServiceProviderRepository,
            ICeremonyServiceProviderRepository ceremonyServiceProviderRepository, IOrganisationRepository organisationRepository,
            ICeremonyServiceProviderAuditingService ceremonyServiceProviderAuditingService, IOrganisationAuditingService organisationAuditingService,
            IMapper mapper)
        {
            this._ceremonyHelpers = ceremonyHelpers;
            this._ceremonyTypeServiceProviderRepository = ceremonyTypeServiceProviderRepository;
            this._ceremonyServiceProviderRepository = ceremonyServiceProviderRepository;
            this._organisationRepository = organisationRepository;
            this._ceremonyServiceProviderAuditingService = ceremonyServiceProviderAuditingService;
            this._organisationAuditingService = organisationAuditingService;
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

            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to create the service provider.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyHelpers.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.ServiceProviders);

            // Make sure there is a ceremony type service provider with the specified code.
            var ceremonyTypeServiceProvider = await this._ceremonyTypeServiceProviderRepository.FindByCode(ceremony.CeremonyTypeId, request.Code);

            if (ceremonyTypeServiceProvider == null)
            {
                throw new CeremonyTypeServiceProviderNotFoundWithCodeException(request.Code);
            }

            // TODO: Handle the scenario where an organisation exists with the supplied name here.

            // Save the organisation.
            // TODO: Save the address and phone numbers of the organisation here.
            var organisationToCreate = this._mapper.Map<Organisation>(request);
            organisationToCreate.Type = OrganisationConstants.ServiceProviderOrganisationType;
            var newOrganisation = await this._organisationRepository.Create(organisationToCreate);

            // Generate and save audit logs for the new oreganisation.
            var organiationAuditEvents = this._organisationAuditingService.GenerateAuditEvents(null, newOrganisation);
            await this._organisationAuditingService.SaveAuditEvents(newOrganisation, currentUser.PersonId, organiationAuditEvents);

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
            return result;
        }
    }
}