using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Repository.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functionality for managing ceremony meeting question files.
    /// </summary>
    public class CeremonyMeetingQuestionFileService : ICeremonyMeetingQuestionFileService
    {
        private readonly ICeremonyHelpers _ceremonyHelpers;
        private readonly ICeremonyFileService _ceremonyFileService;
        private readonly ICeremonyMeetingQuestionRepository _ceremonyMeetingQuestionRepository;
        private readonly ICeremonyMeetingQuestionFileRepository _ceremonyMeetingQuestionFileRepository;
        private readonly ICeremonyTypeFileCategoryRepository _ceremonyTypeFileCategoryRepository;
        private readonly ICeremonyMeetingQuestionFileAuditingService _ceremonyMeetingQuestionFileAuditingService;

        /// <summary>
        /// Creates a new instance of CeremonyMeetingQuestionFileRepository.
        /// </summary>
        /// <param name="ceremonyHelpers">The ceremony helpers.</param>
        /// <param name="ceremonyFileService">The ceremony files service.</param>
        /// <param name="ceremonyMeetingQuestionRepository">The ceremony meeting questions repository.</param>
        /// <param name="ceremonyMeetingQuestionFileRepository">The ceremony meeting question files repository.</param>
        /// <param name="ceremonyTypeFileCategoryRepository">The ceremony type file categories repository.</param>
        /// <param name="ceremonyMeetingQuestionFileAuditingService">The ceremony meeting question file auditing service.</param>
        public CeremonyMeetingQuestionFileService(ICeremonyHelpers ceremonyHelpers, ICeremonyFileService ceremonyFileService,
            ICeremonyMeetingQuestionRepository ceremonyMeetingQuestionRepository, ICeremonyMeetingQuestionFileRepository ceremonyMeetingQuestionFileRepository, 
            ICeremonyTypeFileCategoryRepository ceremonyTypeFileCategoryRepository, ICeremonyMeetingQuestionFileAuditingService ceremonyMeetingQuestionFileAuditingService)
        {
            this._ceremonyHelpers = ceremonyHelpers;
            this._ceremonyFileService = ceremonyFileService;
            this._ceremonyMeetingQuestionRepository = ceremonyMeetingQuestionRepository;
            this._ceremonyMeetingQuestionFileRepository = ceremonyMeetingQuestionFileRepository;
            this._ceremonyTypeFileCategoryRepository = ceremonyTypeFileCategoryRepository;
            this._ceremonyMeetingQuestionFileAuditingService = ceremonyMeetingQuestionFileAuditingService;
            this._ceremonyMeetingQuestionFileAuditingService = ceremonyMeetingQuestionFileAuditingService;
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

            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(ceremonyMeetingQuestion.CeremonyMeeting.CeremonyId, currentUserId);

            // Make sure the user has permissions to add the file.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyHelpers.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, CeremonyFieldNames.Meetings);

            // Create a ceremony file.
            var ceremonyTypeFileCategory = await this._ceremonyTypeFileCategoryRepository.FindByCode(ceremony.CeremonyTypeId, CeremonyTypeFileCategoryConstants.MeetingCode);

            var createCeremonyFileRequest = new CreateCeremonyFileRequest()
            {
                CategoryId = ceremonyTypeFileCategory.Id,
                Description = file.Description,
                FileData = file.FileData
            };

            var ceremonyFile = await this._ceremonyFileService.Create(createCeremonyFileRequest, ceremony.Id, currentUserId);

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
    }
}