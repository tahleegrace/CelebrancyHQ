﻿using AutoMapper;

using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Repository.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functionality for managing ceremony meetings.
    /// </summary>
    public class CeremonyMeetingService : ICeremonyMeetingService
    {
        private readonly ICeremonyHelpers _ceremonyHelpers;
        private readonly ICeremonyTypeMeetingRepository _ceremonyTypeMeetingRepository;
        private readonly ICeremonyTypeMeetingQuestionRepository _ceremonyTypeMeetingQuestionRepository;
        private readonly ICeremonyMeetingRepository _ceremonyMeetingRepository;
        private readonly ICeremonyMeetingQuestionRepository _ceremonyMeetingQuestionRepository;
        private readonly ICeremonyMeetingAuditingService _ceremonyMeetingAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyMeetingService.
        /// </summary>
        /// <param name="ceremonyHelpers">The ceremony helpers.</param>
        /// <param name="ceremonyTypeMeetingRepository">The ceremony type meeting repository.</param>
        /// <param name="ceremonyTypeMeetingQuestionRepository">The ceremony type meeting question repository.</param>
        /// <param name="ceremonyMeetingRepository">The ceremony meeting repository.</param>
        /// <param name="ceremonyMeetingQuestionRepository">The ceremony meeting question repository.</param>
        /// <param name="ceremonyMeetingAuditingService">The ceremony meeting auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyMeetingService(ICeremonyHelpers ceremonyHelpers, ICeremonyTypeMeetingRepository ceremonyTypeMeetingRepository, 
            ICeremonyTypeMeetingQuestionRepository ceremonyTypeMeetingQuestionRepository, ICeremonyMeetingRepository ceremonyMeetingRepository, 
            ICeremonyMeetingQuestionRepository ceremonyMeetingQuestionRepository, ICeremonyMeetingAuditingService ceremonyMeetingAuditingService, IMapper mapper)
        {
            this._ceremonyHelpers = ceremonyHelpers;
            this._ceremonyTypeMeetingRepository = ceremonyTypeMeetingRepository;
            this._ceremonyTypeMeetingQuestionRepository = ceremonyTypeMeetingQuestionRepository;
            this._ceremonyMeetingRepository = ceremonyMeetingRepository;
            this._ceremonyMeetingQuestionRepository = ceremonyMeetingQuestionRepository;
            this._ceremonyMeetingAuditingService = ceremonyMeetingAuditingService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Creates a new ceremony meeting.
        /// </summary>
        /// <param name="meeting">The meeting.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created ceremony meeting.</returns>
        public async Task<CeremonyMeetingDTO> Create(CreateCeremonyMeetingRequest meeting, int ceremonyId, int currentUserId)
        {
            if (meeting == null)
            {
                throw new CeremonyMeetingNotProvidedException();
            }

            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to add the date.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyHelpers.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Meetings);

            // Make sure a ceremony type meeting exists with the specified ID.
            var ceremonyTypeMeeting = await this._ceremonyTypeMeetingRepository.FindById(meeting.CeremonyTypeMeetingId);

            if (ceremonyTypeMeeting == null)
            {
                throw new CeremonyTypeMeetingNotFoundException(meeting.CeremonyTypeMeetingId);
            }

            // Save the meeting.
            var meetingToCreate = this._mapper.Map<CeremonyMeeting>(meeting);
            meetingToCreate.CeremonyId = ceremonyId;
            meetingToCreate.CeremonyTypeMeetingId = meeting.CeremonyTypeMeetingId;

            var newMeeting = await this._ceremonyMeetingRepository.Create(meetingToCreate);

            // Create questions for the meeting.
            var ceremonyTypeMeetingQuestions = await this._ceremonyTypeMeetingQuestionRepository.FindByCeremonyTypeMeetingId(ceremonyTypeMeeting.Id);
            var ceremonyQuestions = ceremonyTypeMeetingQuestions.Select(ctmq => new CeremonyMeetingQuestion()
            {
                CeremonyMeetingId = newMeeting.Id,
                CeremonyTypeMeetingQuestionId = ctmq.Id
            }).ToList();

            await this._ceremonyMeetingQuestionRepository.Create(ceremonyQuestions);

            // Generate and save audit logs for the meeting.
            var auditEvents = this._ceremonyMeetingAuditingService.GenerateAuditEvents(null, newMeeting);
            await this._ceremonyMeetingAuditingService.SaveAuditEvents(newMeeting, ceremony, currentUser.PersonId, auditEvents);

            return this._mapper.Map<CeremonyMeetingDTO>(newMeeting);
        }
    }
}