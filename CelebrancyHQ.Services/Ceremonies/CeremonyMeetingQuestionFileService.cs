using AutoMapper;

using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.Files;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Repository.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functionality for managing ceremony meeting question files.
    /// </summary>
    public class CeremonyMeetingQuestionFileService : ICeremonyMeetingQuestionFileService
    {
        private readonly ICeremonyPermissionService _ceremonyPermissionService;
        private readonly ICeremonyFileService _ceremonyFileService;
        private readonly ICeremonyMeetingRepository _ceremonyMeetingRepository;
        private readonly ICeremonyMeetingQuestionRepository _ceremonyMeetingQuestionRepository;
        private readonly ICeremonyMeetingQuestionFileRepository _ceremonyMeetingQuestionFileRepository;
        private readonly ICeremonyTypeFileCategoryRepository _ceremonyTypeFileCategoryRepository;
        private readonly ICeremonyMeetingQuestionFileAuditingService _ceremonyMeetingQuestionFileAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyMeetingQuestionFileRepository.
        /// </summary>
        /// <param name="ceremonyPermissionService">The ceremony permission service.</param>
        /// <param name="ceremonyFileService">The ceremony files service.</param>
        /// <param name="ceremonyMeetingRepository">The ceremony meetings repository.</param>
        /// <param name="ceremonyMeetingQuestionRepository">The ceremony meeting questions repository.</param>
        /// <param name="ceremonyMeetingQuestionFileRepository">The ceremony meeting question files repository.</param>
        /// <param name="ceremonyTypeFileCategoryRepository">The ceremony type file categories repository.</param>
        /// <param name="ceremonyMeetingQuestionFileAuditingService">The ceremony meeting question file auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyMeetingQuestionFileService(ICeremonyPermissionService ceremonyPermissionService, ICeremonyFileService ceremonyFileService,
            ICeremonyMeetingRepository ceremonyMeetingRepository, ICeremonyMeetingQuestionRepository ceremonyMeetingQuestionRepository, 
            ICeremonyMeetingQuestionFileRepository ceremonyMeetingQuestionFileRepository, ICeremonyTypeFileCategoryRepository ceremonyTypeFileCategoryRepository, 
            ICeremonyMeetingQuestionFileAuditingService ceremonyMeetingQuestionFileAuditingService, IMapper mapper)
        {
            this._ceremonyPermissionService = ceremonyPermissionService;
            this._ceremonyFileService = ceremonyFileService;
            this._ceremonyMeetingRepository = ceremonyMeetingRepository;
            this._ceremonyMeetingQuestionRepository = ceremonyMeetingQuestionRepository;
            this._ceremonyMeetingQuestionFileRepository = ceremonyMeetingQuestionFileRepository;
            this._ceremonyTypeFileCategoryRepository = ceremonyTypeFileCategoryRepository;
            this._ceremonyMeetingQuestionFileAuditingService = ceremonyMeetingQuestionFileAuditingService;
            this._ceremonyMeetingQuestionFileAuditingService = ceremonyMeetingQuestionFileAuditingService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Gets the files for the specified ceremony meeting.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The files for the specified ceremony meeting.</returns>
        public async Task<List<CeremonyFileDTO>> GetMeetingFiles(int meetingId, int currentUserId)
        {
            // Make sure a ceremony meeting exists with the specified ID.
            var ceremonyMeeting = await this._ceremonyMeetingRepository.FindById(meetingId);

            if (ceremonyMeeting == null)
            {
                throw new CeremonyMeetingNotFoundException(meetingId);
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyMeeting.CeremonyId, currentUserId);

            // Get the files for the question.
            var ceremonyMeetingQuestionFiles = await this._ceremonyMeetingQuestionFileRepository.GetMeetingFiles(meetingId);

            var result = ceremonyMeetingQuestionFiles.Select(cmqf =>
            {
                var fileDTO = this._mapper.Map<CeremonyFileDTO>(cmqf.File);
                fileDTO.AdditionalData.questionId = cmqf.QuestionId;

                return fileDTO;
            }).ToList();

            return result;
        }

        /// <summary>
        /// Creates a new ceremony meeting question file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="questionId">The ID of the ceremony meeting question.</param>
        /// <returns>The newly created ceremony file.</returns>
        public async Task<CeremonyFileDTO> Create(CreateCeremonyMeetingQuestionFileRequest file, int questionId, int currentUserId)
        {
            if (file == null)
            {
                throw new CeremonyFileNotProvidedException();
            }

            // Make sure a ceremony meeting question exists with the specified ID.
            var ceremonyMeetingQuestion = await this._ceremonyMeetingQuestionRepository.FindById(questionId);

            if (ceremonyMeetingQuestion == null)
            {
                throw new CeremonyMeetingQuestionNotFoundException(questionId);
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyMeetingQuestion.CeremonyMeeting.CeremonyId, currentUserId);

            // Make sure the user has permissions to add the file.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Meetings);

            // Create a ceremony file.
            var ceremonyTypeFileCategory = await this._ceremonyTypeFileCategoryRepository.FindByCode(ceremony.CeremonyTypeId, CeremonyTypeFileCategoryConstants.MeetingCode);

            var createCeremonyFileRequest = new CreateCeremonyFileRequest()
            {
                CategoryId = ceremonyTypeFileCategory.Id,
                Description = file.Description,
                FileData = file.FileData
            };

            var ceremonyFile = await this._ceremonyFileService.Create(createCeremonyFileRequest, ceremony.Id, currentUserId);
            ceremonyFile.AdditionalData.questionId = questionId;

            // Create a ceremony meeting question file.
            var ceremonyMeetingQuestionFile = new CeremonyMeetingQuestionFile()
            {
                QuestionId = questionId,
                FileId = ceremonyFile.Id
            };

            await this._ceremonyMeetingQuestionFileRepository.Create(ceremonyMeetingQuestionFile);

            // Generate and save audit events for the new file.
            var participantAuditEvents = this._ceremonyMeetingQuestionFileAuditingService.GenerateAuditEvents(null, ceremonyMeetingQuestionFile);
            await this._ceremonyMeetingQuestionFileAuditingService.SaveAuditEvents(ceremonyMeetingQuestionFile, ceremony, currentUser.PersonId, participantAuditEvents);

            return ceremonyFile;
        }

        /// <summary>
        /// Deletes the specified ceremony meeting question file.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        public async Task Delete(int id, int currentUserId)
        {
            var file = await this._ceremonyMeetingQuestionFileRepository.FindById(id);

            if (file == null)
            {
                throw new CeremonyMeetingQuestionFileNotFoundException(id);
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(file.File.CeremonyId, currentUserId);

            // Make sure the user has permissions to delete the file.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, file.File.Category.PermissionCode);

            await this._ceremonyMeetingQuestionFileRepository.Delete(id);
            await this._ceremonyFileService.Delete(file.FileId, currentUserId);

            // Generate and save audit events for the deleted file
            var auditEvents = this._ceremonyMeetingQuestionFileAuditingService.GenerateAuditEvents(file, null);
            await this._ceremonyMeetingQuestionFileAuditingService.SaveAuditEvents(file, ceremony, currentUser.PersonId, auditEvents);
        }
    }
}