using AutoMapper;

using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Constants.CeremonyTypes;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.Exceptions.CeremonyTypes;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.CeremonyTypes;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functions for managing ceremony dates.
    /// </summary>
    public class CeremonyDateService : ICeremonyDateService
    {
        private readonly ICeremonyPermissionService _ceremonyPermissionService;
        private readonly ICeremonyTypeDateRepository _ceremonyTypeDateRepository;
        private readonly ICeremonyDateRepository _ceremonyDateRepository;
        private readonly ICeremonyDateAuditingService _ceremonyDateAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyDateService.
        /// </summary>
        /// <param name="ceremonyPermissionService">The ceremony permission service.</param>
        /// <param name="ceremonyTypeDateRepository">The ceremony type dates repository.</param>
        /// <param name="ceremonyDateRepository">The ceremony dates repository.</param>
        /// <param name="ceremonyDateAuditingService">The ceremony date auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyDateService(ICeremonyPermissionService ceremonyPermissionService, ICeremonyTypeDateRepository ceremonyTypeDateRepository,
            ICeremonyDateRepository ceremonyDateRepository, ICeremonyDateAuditingService ceremonyDateAuditingService, IMapper mapper)
        {
            this._ceremonyPermissionService = ceremonyPermissionService;
            this._ceremonyTypeDateRepository = ceremonyTypeDateRepository;
            this._ceremonyDateRepository = ceremonyDateRepository;
            this._ceremonyDateAuditingService = ceremonyDateAuditingService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Gets the dates for the ceremony with the specified ID.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The dates for the ceremony with the specified ID.</returns>
        public async Task<List<CeremonyDateDTO>> GetDates(int ceremonyId, int currentUserId)
        {
            // TODO: Convert the dates to UTC time here based on the current user's time zone setting.
            var (currentUser, _) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permission to view the dates of the ceremony.
            await this._ceremonyPermissionService.CheckCanViewCeremony(ceremonyId, currentUser.PersonId, CeremonyFieldNames.Dates);

            var dates = await this._ceremonyDateRepository.GetCeremonyDates(ceremonyId);
            var dtos = this._mapper.Map<List<CeremonyDateDTO>>(dates);

            return dtos;
        }

        /// <summary>
        /// Creates a new date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created date.</returns>
        public async Task<CeremonyDateDTO> Create(CreateCeremonyDateRequest date, int ceremonyId, int currentUserId)
        {
            // TODO: Convert the date to UTC.
            if (date == null)
            {
                throw new CeremonyDateNotProvidedException();
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to add the date.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Dates);

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
        public async Task<CeremonyDateDTO?> Update(UpdateCeremonyDateRequest date, int ceremonyId, int currentUserId)
        {
            // TODO: Convert the date to UTC.
            if ((date == null) || (date.Id <= 0 || String.IsNullOrWhiteSpace(date.Code)) || (date.Code == CeremonyTypeDateConstants.OtherCode))
            {
                throw new CeremonyDateNotProvidedException();
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to edit the date.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Dates);

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
    }
}