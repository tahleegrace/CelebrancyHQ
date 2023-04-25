using AutoMapper;

using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.DTOs.Files;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Services.Files;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functionality for managing ceremony files.
    /// </summary>
    public class CeremonyFileService : ICeremonyFileService
    {
        private readonly ICeremonyPermissionService _ceremonyPermissionService;
        private readonly IFileService _fileService;
        private readonly ICeremonyFileRepository _ceremonyFileRepository;
        private readonly ICeremonyTypeFileCategoryRepository _ceremonyTypeFileCategoryRepository;
        private readonly ICeremonyFileAuditingService _ceremonyFileAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyFileService.
        /// </summary>
        /// <param name="ceremonyPermissionService">The ceremony permission service.</param>
        /// <param name="fileService">The file service.</param>
        /// <param name="ceremonyFileRepository">The ceremony files repository.</param>
        /// <param name="ceremonyTypeFileCategoryRepository">The ceremony type file categories repository.</param>
        /// <param name="ceremonyFileAuditingService">The ceremony file auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyFileService(ICeremonyPermissionService ceremonyPermissionService, IFileService fileService, 
            ICeremonyFileRepository ceremonyFileRepository, ICeremonyTypeFileCategoryRepository ceremonyTypeFileCategoryRepository, 
            ICeremonyFileAuditingService ceremonyFileAuditingService, IMapper mapper)
        {
            this._ceremonyPermissionService = ceremonyPermissionService;
            this._fileService = fileService;
            this._ceremonyFileRepository = ceremonyFileRepository;
            this._ceremonyTypeFileCategoryRepository = ceremonyTypeFileCategoryRepository;
            this._ceremonyFileAuditingService = ceremonyFileAuditingService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Gets the files for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The files for the specified ceremony.</returns>
        public async Task<List<CeremonyFileDTO>> GetCeremonyFiles(int ceremonyId, int currentUserId)
        {
            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Find all the fields the user can view files for.
            var effectivePermissions = await this._ceremonyPermissionService.GetEffectivePermissionsForCeremony(ceremonyId, currentUser.PersonId);
            var accessibleFields = effectivePermissions.Select(p => p.Field).Distinct();

            // Get the files for the ceremony.
            var files = await this._ceremonyFileRepository.GetCeremonyFiles(ceremonyId);

            // Get the files that the user has permission to access.
            var accessibleFiles = files.Where(f => accessibleFields.Contains(f.Category.PermissionCode));

            var result = this._mapper.Map<List<CeremonyFileDTO>>(accessibleFiles);
            return result;
        }

        /// <summary>
        /// Downloads the specified file.
        /// </summary>
        /// <param name="fileId">The ID of the file.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The file to download.</returns>
        public async Task<DownloadFileDTO> DownloadFile(int fileId, int currentUserId)
        {
            // TODO: Block downloading of the file if it hasn't been virus scanned.

            // Retrieve the file and make sure it exists.
            var ceremonyFile = await this._ceremonyFileRepository.FindById(fileId);

            if (ceremonyFile == null)
            {
                throw new CeremonyFileNotFoundException(fileId);
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyFile.CeremonyId, currentUserId);

            // Make sure the user has permissions to download the file.
            await this._ceremonyPermissionService.CheckCanViewCeremony(ceremony.Id, currentUser.PersonId, ceremonyFile.Category.PermissionCode);

            return await this._fileService.DownloadFile(ceremonyFile.FileId);
        }

        /// <summary>
        /// Creates a new ceremony file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created ceremony file.</returns>
        public async Task<CeremonyFileDTO> Create(CreateCeremonyFileRequest file, int ceremonyId, int currentUserId)
        {
            if (file == null)
            {
                throw new CeremonyFileNotProvidedException();
            }

            var (currentUser, ceremony) = await this._ceremonyPermissionService.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure a ceremony type file category exists with the specified ID.
            var ceremonyTypeFileCategory = await this._ceremonyTypeFileCategoryRepository.FindById(file.CategoryId);

            if (ceremonyTypeFileCategory == null)
            {
                throw new CeremonyTypeFileCategoryNotFoundException(file.CategoryId);
            }

            // Make sure the user has permissions to add the file.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyPermissionService.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, ceremonyTypeFileCategory.PermissionCode);

            // Save the file.
            var newFile = await this._fileService.CreateFile(file, currentUser.Person);

            // Save the ceremony file.
            var newCeremonyFile = this._mapper.Map<CeremonyFile>(file);
            newCeremonyFile.CeremonyId = ceremonyId;
            newCeremonyFile.FileId = newFile.Id;
            newCeremonyFile = await this._ceremonyFileRepository.Create(newCeremonyFile);

            // Generate and save audit logs for the file.
            var auditEvents = this._ceremonyFileAuditingService.GenerateAuditEvents(null, newCeremonyFile);
            await this._ceremonyFileAuditingService.SaveAuditEvents(newCeremonyFile, ceremony, currentUser.PersonId, auditEvents);

            var result = this._mapper.Map<CeremonyFileDTO>(newCeremonyFile);
            return result;
        }
    }
}