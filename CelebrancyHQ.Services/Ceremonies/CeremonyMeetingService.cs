using AutoMapper;

using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Constants.Forms;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Auditing;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.Persons;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Repository.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functionality for managing ceremony meetings.
    /// </summary>
    public class CeremonyMeetingService : ICeremonyMeetingService
    {
        private readonly ICeremonyPermissionService _ceremonyPermissionService;
        private readonly ICeremonyTypeMeetingRepository _ceremonyTypeMeetingRepository;
        private readonly ICeremonyTypeMeetingQuestionRepository _ceremonyTypeMeetingQuestionRepository;
        private readonly ICeremonyParticipantRepository _ceremonyParticipantRepository;
        private readonly ICeremonyMeetingRepository _ceremonyMeetingRepository;
        private readonly ICeremonyMeetingQuestionRepository _ceremonyMeetingQuestionRepository;
        private readonly ICeremonyMeetingParticipantRepository _ceremonyMeetingParticipantRepository;
        private readonly ICeremonyMeetingAuditingService _ceremonyMeetingAuditingService;
        private readonly ICeremonyMeetingParticipantAuditingService _ceremonyMeetingParticipantAuditingService;
        private readonly ICeremonyMeetingQuestionAuditingService _ceremonyMeetingQuestionAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyMeetingService.
        /// </summary>
        /// <param name="ceremonyPermissionService">The ceremony permission service.</param>
        /// <param name="ceremonyTypeMeetingRepository">The ceremony type meeting repository.</param>
        /// <param name="ceremonyTypeMeetingQuestionRepository">The ceremony type meeting question repository.</param>
        /// <param name="ceremonyParticipantRepository">The ceremony participants repository.</param>
        /// <param name="ceremonyMeetingRepository">The ceremony meeting repository.</param>
        /// <param name="ceremonyMeetingQuestionRepository">The ceremony meeting question repository.</param>
        /// <param name="ceremonyMeetingParticipantRepository">The ceremony meeting participants repository.</param>
        /// <param name="ceremonyMeetingAuditingService">The ceremony meeting auditing service.</param>
        /// <param name="ceremonyMeetingParticipantAuditingService">The ceremony meeting participant auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyMeetingService(ICeremonyPermissionService ceremonyPermissionService, ICeremonyTypeMeetingRepository ceremonyTypeMeetingRepository, 
            ICeremonyParticipantRepository ceremonyParticipantRepository, ICeremonyTypeMeetingQuestionRepository ceremonyTypeMeetingQuestionRepository, 
            ICeremonyMeetingRepository ceremonyMeetingRepository, ICeremonyMeetingQuestionRepository ceremonyMeetingQuestionRepository, 
            ICeremonyMeetingParticipantRepository ceremonyMeetingParticipantRepository, ICeremonyMeetingAuditingService ceremonyMeetingAuditingService, 
            ICeremonyMeetingParticipantAuditingService ceremonyMeetingParticipantAuditingService, 
            ICeremonyMeetingQuestionAuditingService ceremonyMeetingQuestionAuditingService, IMapper mapper)
        {
            this._ceremonyPermissionService = ceremonyPermissionService;
            this._ceremonyTypeMeetingRepository = ceremonyTypeMeetingRepository;
            this._ceremonyTypeMeetingQuestionRepository = ceremonyTypeMeetingQuestionRepository;
            this._ceremonyParticipantRepository = ceremonyParticipantRepository;
            this._ceremonyMeetingRepository = ceremonyMeetingRepository;
            this._ceremonyMeetingQuestionRepository = ceremonyMeetingQuestionRepository;
            this._ceremonyMeetingParticipantRepository = ceremonyMeetingParticipantRepository;
            this._ceremonyMeetingAuditingService = ceremonyMeetingAuditingService;
            this._ceremonyMeetingParticipantAuditingService = ceremonyMeetingParticipantAuditingService;
            this._ceremonyMeetingQuestionAuditingService = ceremonyMeetingQuestionAuditingService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Gets the ceremony meeting with the specified ID.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The ceremony meeting with the specified ID.</returns>
        public async Task<CeremonyMeetingDTO> GetCeremonyMeeting(int meetingId, int currentUserId)
        {
            // Retrieve the meeting and make sure it exists.
            var meeting = await this._ceremonyMeetingRepository.FindById(meetingId);

            if (meeting == null)
            {
                throw new CeremonyMeetingNotFoundException(meetingId);
            }

            // Make sure the user has permissions to view the meetings for the ceremony.
            var (currentUser, _) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(meeting.CeremonyId, currentUserId);

            await this._ceremonyPermissionService.CheckCanViewCeremony(meeting.CeremonyId, currentUser.PersonId, CeremonyFieldNames.Meetings);

            // Retrieve the participants for the meeting.
            var participants = await this._ceremonyMeetingParticipantRepository.GetParticipantsForMeeting(meetingId);

            var result = this._mapper.Map<CeremonyMeetingDTO>(meeting);
            result.Participants = participants.Select(participant => this._mapper.Map<PersonDTO>(participant.Person)).ToList();

            // Retrieve the questions for the meeting.
            var questions = await this._ceremonyMeetingQuestionRepository.GetQuestionsForMeeting(meetingId);
            var ceremonyTypeMeetingQuestions = await this._ceremonyTypeMeetingQuestionRepository.FindByCeremonyTypeMeetingId(meeting.CeremonyTypeMeetingId);

            result.Questions = ceremonyTypeMeetingQuestions.Select(ceremonyTypeMeetingQuestion =>
            {
                var meetingQuestion = questions.Where(q => q.CeremonyTypeMeetingQuestionId == ceremonyTypeMeetingQuestion.Id).FirstOrDefault();

                return new CeremonyMeetingQuestionDTO()
                {
                    Id = meetingQuestion?.Id,
                    CeremonyTypeQuestionId = ceremonyTypeMeetingQuestion.Id,
                    QuestionTypeCode = ceremonyTypeMeetingQuestion.QuestionType.Code,
                    Question = ceremonyTypeMeetingQuestion.Question,
                    QuestionDescription = ceremonyTypeMeetingQuestion.Description,
                    Answer = meetingQuestion?.Answer
                };
            }).ToList();

            return result;
        }

        /// <summary>
        /// Gets the meetings for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The meetings for the specified ceremony.</returns>
        public async Task<List<CeremonyMeetingDTO>> GetCeremonyMeetings(int ceremonyId, int currentUserId)
        {
            var (currentUser, _) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to view the meetings for the ceremony.
            await this._ceremonyPermissionService.CheckCanViewCeremony(ceremonyId, currentUser.PersonId, CeremonyFieldNames.Meetings);

            // Get the meetings for the ceremony.
            var meetings = await this._ceremonyMeetingRepository.GetCeremonyMeetings(ceremonyId);

            var result = this._mapper.Map<List<CeremonyMeetingDTO>>(meetings);
            return result;
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

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure the user has permissions to add the meeting.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Meetings);

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

            // Create participants for the meeting.
            var newParticipants = new List<PersonDTO>();

            if (meeting.Participants != null)
            {
                foreach (var participantId in meeting.Participants)
                {
                    var isCeremonyParticipant = await this._ceremonyParticipantRepository.PersonIsCeremonyParticipant(participantId, ceremonyId);

                    if (!isCeremonyParticipant)
                    {
                        throw new PersonNotCeremonyParticipantException(participantId);
                    }

                    var newParticipant = new CeremonyMeetingParticipant()
                    {
                        CeremonyMeetingId = newMeeting.Id,
                        PersonId = participantId
                    };

                    newParticipant = await this._ceremonyMeetingParticipantRepository.Create(newParticipant);
                    newParticipants.Add(this._mapper.Map<PersonDTO>(newParticipant.Person));

                    var participantAuditEvents = this._ceremonyMeetingParticipantAuditingService.GenerateAuditEvents(null, newParticipant);
                    await this._ceremonyMeetingParticipantAuditingService.SaveAuditEvents(newParticipant, ceremony, currentUser.PersonId, participantAuditEvents);
                }
            }

            var result = this._mapper.Map<CeremonyMeetingDTO>(newMeeting);
            result.Participants = newParticipants;
            return result;
        }

        /// <summary>
        /// Updates the details of the specified ceremony meeting.
        /// </summary>
        /// <param name="meeting">The meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task Update(UpdateCeremonyMeetingRequest meeting, int currentUserId)
        {
            // Make sure the ceremony meeting has been provided and has an ID.
            if ((meeting == null) || (meeting.Id <= 0))
            {
                throw new CeremonyMeetingNotProvidedException();
            }

            var existingMeeting = await this._ceremonyMeetingRepository.FindById(meeting.Id);

            if (existingMeeting == null)
            {
                throw new CeremonyMeetingNotFoundException(meeting.Id);
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(existingMeeting.CeremonyId, currentUserId);

            // Make sure the user has permissions to update the meeting.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Meetings);

            // Generate audit logs for the meeting.
            var newMeetingForAuditing = this._mapper.Map<CeremonyMeeting>(existingMeeting);
            this._mapper.Map(meeting, newMeetingForAuditing);

            var auditEvents = this._ceremonyMeetingAuditingService.GenerateAuditEvents(existingMeeting, newMeetingForAuditing);

            // Save the meeting.
            this._mapper.Map(meeting, existingMeeting);

            await this._ceremonyMeetingRepository.Update(existingMeeting);

            // Save the audit logs for the meeting.
            await this._ceremonyMeetingAuditingService.SaveAuditEvents(existingMeeting, ceremony, currentUser.PersonId, auditEvents);
        }

        /// <summary>
        /// Updates the specified ceremony meeting question.
        /// </summary>
        /// <param name="question">The question.</param>
        /// <param name="meetingId">The meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task UpdateQuestion(UpdateCeremonyMeetingQuestionRequest question, int meetingId, int currentUserId)
        {
            // Make sure the ceremony meeting question has been provided and has an ID.
            if ((question == null) || (question.CeremonyTypeQuestionId <= 0))
            {
                throw new CeremonyMeetingQuestionNotProvidedException();
            }

            // Make sure the meeting exists.
            var meeting = await this._ceremonyMeetingRepository.FindById(meetingId);

            if (meeting == null)
            {
                throw new CeremonyMeetingNotFoundException(meetingId);
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(meeting.CeremonyId, currentUserId);

            // Make sure the user has permissions to update the question.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Meetings);

            // Make sure the ceremony type meeting question exists and it belongs to the ceremony type meeting.
            var ceremonyTypeMeetingQuestion = await this._ceremonyTypeMeetingQuestionRepository.FindById(question.CeremonyTypeQuestionId);

            if (ceremonyTypeMeetingQuestion?.CeremonyTypeMeetingId != meeting.CeremonyTypeMeetingId)
            {
                throw new CeremonyTypeMeetingQuestionNotFoundException(question.CeremonyTypeQuestionId);
            }

            var questionToUpdate = await this._ceremonyMeetingQuestionRepository.FindByCeremonyTypeMeetingQuestionId(meetingId, question.CeremonyTypeQuestionId);

            if (questionToUpdate == null)
            {
                questionToUpdate = new CeremonyMeetingQuestion()
                {
                    CeremonyMeetingId = meetingId,
                    CeremonyTypeMeetingQuestionId = question.CeremonyTypeQuestionId
                };

                await this._ceremonyMeetingQuestionRepository.Create(new List<CeremonyMeetingQuestion> { questionToUpdate });
            }

            // TODO: Handle field types other than text fields here.
            List<AuditEvent> auditEvents = null;

            if (ceremonyTypeMeetingQuestion.QuestionType.Code == FormFieldTypeConstants.TextFieldCode)
            {
                // Generate audit logs for the question.
                var newQuestionForAuditing = new CeremonyMeetingQuestion()
                {
                    Id = questionToUpdate.Id,
                    CeremonyMeetingId = meetingId,
                    CeremonyTypeMeetingQuestionId = question.CeremonyTypeQuestionId,
                    Answer = question.Answer
                };

                auditEvents = this._ceremonyMeetingQuestionAuditingService.GenerateAuditEvents(questionToUpdate, newQuestionForAuditing);

                questionToUpdate.Answer = question.Answer;
                await this._ceremonyMeetingQuestionRepository.Update(questionToUpdate);
            }

            // Save the audit logs for the question.
            await this._ceremonyMeetingQuestionAuditingService.SaveAuditEvents(questionToUpdate, ceremony, currentUserId, auditEvents);
        }

        /// <summary>
        /// Creates a new ceremony meeting participant.
        /// </summary>
        /// <param name="personId">The ID of the person to be added as a participant.</param>
        /// <param name="meetingId">The ID of the participant.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created participant.</returns>
        public async Task<PersonDTO> CreateParticipant(int personId, int meetingId, int currentUserId)
        {
            // Make sure a ceremony meeting exists with the specified ID.
            var meeting = await this._ceremonyMeetingRepository.FindById(meetingId);

            if (meeting == null)
            {
                throw new CeremonyMeetingNotFoundException(meetingId);
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(meeting.CeremonyId, currentUserId);

            // Make sure the user has permissions to update the meeting.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Meetings);

            // Make sure the person is not already a participant in the meeting.
            var isMeetingParticipant = await this._ceremonyMeetingParticipantRepository.ParticipantExistsWithPersonId(meetingId, personId);

            if (isMeetingParticipant)
            {
                throw new PersonAlreadyCeremonyMeetingParticipantException(meetingId, personId);
            }

            // Make sure the person is a ceremony participant.
            var isCeremonyParticipant = await this._ceremonyParticipantRepository.PersonIsCeremonyParticipant(personId, meeting.CeremonyId);

            if (!isCeremonyParticipant)
            {
                throw new PersonNotCeremonyParticipantException(personId);
            }

            var newParticipant = new CeremonyMeetingParticipant()
            {
                CeremonyMeetingId = meeting.Id,
                PersonId = personId
            };

            newParticipant = await this._ceremonyMeetingParticipantRepository.Create(newParticipant);

            // Generate and save audit events for the new participant.
            var participantAuditEvents = this._ceremonyMeetingParticipantAuditingService.GenerateAuditEvents(null, newParticipant);
            await this._ceremonyMeetingParticipantAuditingService.SaveAuditEvents(newParticipant, ceremony, currentUser.PersonId, participantAuditEvents);

            var result = this._mapper.Map<PersonDTO>(newParticipant.Person);
            return result;
        }

        /// <summary>
        /// Deletes a ceremony meeting participant.
        /// </summary>
        /// <param name="personId">The ID of the person to be removed as a participant.</param>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task DeleteParticipant(int personId, int meetingId, int currentUserId)
        {
            // Make sure a ceremony meeting exists with the specified ID.
            var meeting = await this._ceremonyMeetingRepository.FindById(meetingId);

            if (meeting == null)
            {
                throw new CeremonyMeetingNotFoundException(meetingId);
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(meeting.CeremonyId, currentUserId);

            // Make sure the user has permissions to update the meeting.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Meetings);

            // Make sure there is a participant with the specified person ID.
            var participant = await this._ceremonyMeetingParticipantRepository.FindByPersonId(meetingId, personId);

            if (participant == null)
            {
                throw new CeremonyMeetingParticipantNotFoundException(meetingId, personId);
            }

            // Delete the participant.
            await this._ceremonyMeetingParticipantRepository.Delete(participant.Id);

            // Generate and save audit events for the deleted participant.
            var participantAuditEvents = this._ceremonyMeetingParticipantAuditingService.GenerateAuditEvents(participant, null);
            await this._ceremonyMeetingParticipantAuditingService.SaveAuditEvents(participant, ceremony, currentUser.PersonId, participantAuditEvents);
        }
    }
}