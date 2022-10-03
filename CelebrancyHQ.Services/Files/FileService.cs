using AutoMapper;

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
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of FileService.
        /// </summary>
        /// <param name="fileRepository">The files repository.</param>
        /// <param name="mapper">The mapper.</param>
        public FileService(IFileRepository fileRepository, IMapper mapper)
        {
            this._fileRepository = fileRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="currentUserId">The ID of the current user.</param>
        /// <returns>The newly created file.</returns>
        public async Task<FileDTO> CreateFile(CreateFileRequest file, int currentUserId)
        {
            if (file == null)
            {
                throw new FileNotProvidedException();
            }

            // Create the file.
            var newFile = this._mapper.Map<Entities.File>(file);
            newFile.CreatedById = currentUserId;
            newFile.Status = FileStatus.Pending;
            newFile = await this._fileRepository.Create(newFile);

            // TODO: Scan the file for viruses.
            // TODO: Add audit logs for creating file.

            var result = this._mapper.Map<FileDTO>(newFile);
            return result;
        }
    }
}