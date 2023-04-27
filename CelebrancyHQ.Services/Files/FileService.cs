using AutoMapper;

using CelebrancyHQ.Auditing.Files;
using CelebrancyHQ.Entities;
using CelebrancyHQ.Entities.Constants.Files;
using CelebrancyHQ.Models.DTOs.Files;
using CelebrancyHQ.Models.Exceptions.Files;
using CelebrancyHQ.Repository.Files;

namespace CelebrancyHQ.Services.Files
{
    /// <summary>
    /// Provides functionality for managing files.
    /// </summary>
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileAuditingService _fileAuditingService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of FileService.
        /// </summary>
        /// <param name="fileRepository">The files repository.</param>
        /// <param name="fileAuditingService">The file auditing service.</param>
        /// <param name="mapper">The mapper.</param>
        public FileService(IFileRepository fileRepository, IFileAuditingService fileAuditingService, IMapper mapper)
        {
            this._fileRepository = fileRepository;
            this._fileAuditingService = fileAuditingService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="currentUser">The current user.</param>
        /// <returns>The newly created file.</returns>
        public async Task<FileDTO> Create(CreateFileRequest file, Person currentUser)
        {
            if (file == null)
            {
                throw new FileNotProvidedException();
            }

            // Read the data in the file.
            byte[] fileData;

            using (MemoryStream ms = new MemoryStream())
            {
                await file.FileData.CopyToAsync(ms);
                fileData = ms.ToArray();
            }

            // Create the file.
            var newFile = this._mapper.Map<Entities.File>(file);
            newFile.CreatedById = currentUser.Id;
            newFile.Status = FileStatus.Pending;
            newFile.FileData = fileData;
            newFile.Size = fileData.Length;
            newFile = await this._fileRepository.Create(newFile);

            // Generate and save audit logs for creating the file.
            var auditEvents = this._fileAuditingService.GenerateAuditEvents(null, newFile);
            await this._fileAuditingService.SaveAuditEvents(newFile, currentUser.Id, auditEvents);

            // TODO: Scan the file for viruses.

            var result = this._mapper.Map<FileDTO>(newFile);
            return result;
        }

        /// <summary>
        /// Downloads the specified file.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <returns>The file to download.</returns>
        public async Task<DownloadFileDTO> DownloadFile(int id)
        {
            var file = await this._fileRepository.FindById(id);

            if (file == null)
            {
                throw new CelebrancyHQ.Models.Exceptions.Files.FileNotFoundException(id);
            }

            var result = this._mapper.Map<DownloadFileDTO>(file);
            return result;
        }

        /// <summary>
        /// Deletes the file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        public async Task Delete(int id)
        {
            var file = await this._fileRepository.FindById(id);

            if (file == null)
            {
                throw new CelebrancyHQ.Models.Exceptions.Files.FileNotFoundException(id);
            }

            // TODO: Generate audit logs for deleting the file.

            await this._fileRepository.Delete(id);
        }
    }
}