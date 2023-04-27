using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Files;
using CelebrancyHQ.Models.DTOs.Files;

namespace CelebrancyHQ.API.Controllers
{
    /// <summary>
    /// Provides functionality for managing ceremony files.
    /// </summary>
    [Route("api/ceremonies")]
    [Authorize]
    [ApiController]
    public class CeremonyFilesController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICeremonyFileService _ceremonyFileService;

        /// <summary>
        /// Creates a new instance of CeremonyFilesController.
        /// </summary>
        /// <param name="authenticationService">The authentication service.</param>
        /// <param name="ceremonyMeetingService">The ceremony files service.</param>
        public CeremonyFilesController(IAuthenticationService authenticationService, ICeremonyFileService ceremonyFileService)
        {
            this._authenticationService = authenticationService;
            this._ceremonyFileService = ceremonyFileService;
        }

        /// <summary>
        /// Gets all the files for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The files for the specified ceremony.</returns>
        [HttpGet("{ceremonyId}/files")]
        public async Task<ActionResult<List<CeremonyFileDTO>>> GetAll(int ceremonyId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyFileService.GetCeremonyFiles(ceremonyId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotViewCeremonyDetailsException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Gets the file with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <returns>The file with the specified id.</returns>
        [HttpGet("{ceremonyId}/files/{id}")]
        public async Task<ActionResult<DownloadFileDTO>> Get(int id)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyFileService.DownloadFile(id, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyFileNotFoundException || ex is CelebrancyHQ.Models.Exceptions.Files.FileNotFoundException 
                || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotViewCeremonyDetailsException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="request">The file.</param>
        /// <returns>The newly created file.</returns>
        [HttpPost("{ceremonyId}/files")]
        public async Task<ActionResult<CeremonyFileDTO>> Create(int ceremonyId, [FromForm] CreateCeremonyFileRequest request)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyFileService.Create(request, ceremonyId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyTypeFileCategoryNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is CeremonyFileNotProvidedException || ex is FileNotProvidedException)
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Updates the details of the specified ceremony file.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="fileId">The ID of the file.</param>
        /// <param name="request">The file.</param>
        [HttpPut("{ceremonyId}/files/{fileId}")]
        public async Task<ActionResult> Update(int ceremonyId, int fileId, UpdateCeremonyFileRequest request)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                await this._ceremonyFileService.Update(request, currentUserId.Value);

                return NoContent();
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyFileNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is CeremonyFileNotProvidedException)
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="participantId">The ID of the file.</param>
        [HttpDelete("{ceremonyId}/files/{fileId}")]
        public async Task<ActionResult> Delete(int ceremonyId, int fileId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                await this._ceremonyFileService.Delete(fileId, currentUserId.Value);

                return NoContent();
            }
            catch (Exception ex) when (ex is CeremonyFileNotFoundException || ex is CelebrancyHQ.Models.Exceptions.Files.FileNotFoundException 
                || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }
    }
}