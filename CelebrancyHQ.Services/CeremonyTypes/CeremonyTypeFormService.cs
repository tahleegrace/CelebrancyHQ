﻿using AutoMapper;

using CelebrancyHQ.Models.DTOs.CeremonyTypes;
using CelebrancyHQ.Models.Exceptions.CeremonyTypes;
using CelebrancyHQ.Repository.CeremonyTypes;

namespace CelebrancyHQ.Services.CeremonyTypes
{
    /// <summary>
    /// Provides functionality for managing ceremony type forms.
    /// </summary>
    public class CeremonyTypeFormService : ICeremonyTypeFormService
    {
        private readonly ICeremonyTypePermissionService _ceremonyTypePermissionService;
        private readonly ICeremonyTypeFormRepository _ceremonyTypeFormRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyTypeFormService.
        /// </summary>
        /// <param name="ceremonyTypePermissionService">The ceremony type permissions service.</param>
        /// <param name="ceremonyTypeFormRepository">The ceremony type forms repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyTypeFormService(ICeremonyTypePermissionService ceremonyTypePermissionService, ICeremonyTypeFormRepository ceremonyTypeFormRepository, 
            IMapper mapper)
        {
            this._ceremonyTypePermissionService = ceremonyTypePermissionService;
            this._ceremonyTypeFormRepository = ceremonyTypeFormRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Gets the ceremony type form with the specified ID.
        /// </summary>
        /// <param name="formId">The ID of the form.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The ceremony type form with the specified ID.</returns>
        public async Task<CeremonyTypeFormDTO> GetCeremonyTypeForm(int formId, int currentUserId)
        {
            // Retrieve the form and make sure it exists.
            var form = await this._ceremonyTypeFormRepository.FindById(formId);

            if (form == null)
            {
                throw new CeremonyTypeFormNotFoundException(formId);
            }

            // Make sure the user has permissions to view the forms for the ceremony type.
            var (currentUser, _) = await this._ceremonyTypePermissionService.CheckCeremonyTypeIsAccessible(form.CeremonyTypeId, currentUserId);

            //await this._ceremonyTypePermissionService.CheckCanViewCeremonyType(form.CeremonyTypeId, currentUser.PersonId, CeremonyTypeFieldNames.Forms);

            var result = this._mapper.Map<CeremonyTypeFormDTO>(form);
            return result;
        }

        /// <summary>
        /// Finds the ceremony type forms that can be offered by the current user's organisation.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The ceremony type forms that can be offered by the current user's organisation for the specified ceremony type.</returns>
        public async Task<List<CeremonyTypeFormDTO>> GetAllCeremonyTypeForms(int ceremonyTypeId, int currentUserId)
        {
            // Make sure the user has permissions to view the forms for the ceremony type.
            var (currentUser, _) = await this._ceremonyTypePermissionService.CheckCeremonyTypeIsAccessible(ceremonyTypeId, currentUserId);

            //await this._ceremonyTypePermissionService.CheckCanViewCeremonyType(ceremonyTypeId, currentUser.PersonId, CeremonyTypeFieldNames.Forms);

            var forms = await this._ceremonyTypeFormRepository.FindByOrganisationId(ceremonyTypeId, currentUser.Person.OrganisationId);

            var result = this._mapper.Map<List<CeremonyTypeFormDTO>>(forms);
            return result;
        }
    }
}