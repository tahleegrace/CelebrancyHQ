using AutoMapper;

using CelebrancyHQ.Entities;
using CelebrancyHQ.Services.Files;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Ceremonies;

namespace CelebrancyHQ.Services.Ceremonies
{
    /// <summary>
    /// Provides functionality for managing ceremony files.
    /// </summary>
    public class CeremonyFileService : ICeremonyFileService
    {
        private readonly ICeremonyHelpers _ceremonyHelpers;
        private readonly IFileService _fileService;
        private readonly ICeremonyFileRepository _ceremonyFileRepository;
        private readonly ICeremonyTypeFileCategoryRepository _ceremonyTypeFileCategoryRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of CeremonyFileService.
        /// </summary>
        /// <param name="ceremonyHelpers">The ceremony helpers.</param>
        /// <param name="fileService">The file service.</param>
        /// <param name="ceremonyFileRepository">The ceremony files repository.</param>
        /// <param name="ceremonyTypeFileCategoryRepository">The ceremony type file categories repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CeremonyFileService(ICeremonyHelpers ceremonyHelpers, IFileService fileService, 
            ICeremonyFileRepository ceremonyFileRepository, ICeremonyTypeFileCategoryRepository ceremonyTypeFileCategoryRepository, IMapper mapper)
        {
            this._ceremonyHelpers = ceremonyHelpers;
            this._fileService = fileService;
            this._ceremonyFileRepository = ceremonyFileRepository;
            this._ceremonyTypeFileCategoryRepository = ceremonyTypeFileCategoryRepository;
            this._mapper = mapper;
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

            var (currentUser, ceremony) = await this._ceremonyHelpers.CheckCeremonyIsAccessible(ceremonyId, currentUserId);

            // Make sure a ceremony type file category exists with the specified ID.
            var ceremonyTypeFileCategory = await this._ceremonyTypeFileCategoryRepository.FindById(file.CategoryId);

            if (ceremonyTypeFileCategory == null)
            {
                throw new CeremonyTypeFileCategoryNotFoundException(file.CategoryId);
            }

            // Make sure the user has permissions to add the file.
            // TODO: Handle the scenario where changes to the ceremony need to be approved here.
            await this._ceremonyHelpers.CheckCanEditCeremony(ceremony.Id, currentUser.PersonId, ceremonyTypeFileCategory.PermissionCode);

            // Save the file.
            var newFile = await this._fileService.CreateFile(file, currentUser.Person);

            // Save the ceremony file.
            var newCeremonyFile = this._mapper.Map<CeremonyFile>(file);
            newCeremonyFile.CeremonyId = ceremonyId;
            newCeremonyFile.FileId = newFile.Id;
            newCeremonyFile = await this._ceremonyFileRepository.Create(newCeremonyFile);

            // TODO: Add audit logs for creating a ceremony file.

            var result = this._mapper.Map<CeremonyFileDTO>(newCeremonyFile);
            return result;
        }
    }
}