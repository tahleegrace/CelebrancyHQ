﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.DTOs.Persons;
using CelebrancyHQ.Models.Exceptions.CeremonyTypes;

namespace CelebrancyHQ.API.Controllers
{
    /// <summary>
    /// Provides functionality for managing ceremony meetings.
    /// </summary>
    [Route("api/ceremonies")]
    [Authorize]
    [ApiController]
    public class CeremonyMeetingsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICeremonyMeetingService _ceremonyMeetingService;
        private readonly ICeremonyMeetingQuestionFileService _ceremonyMeetingQuestionFileService;

        /// <summary>
        /// Creates a new instance of CeremonyMeetingsController.
        /// </summary>
        /// <param name="authenticationService">The authentication service.</param>
        /// <param name="ceremonyMeetingService">The ceremony meetings service.</param>
        /// <param name="ceremonyMeetingQuestionFileService">The ceremony meeting question files service.</param>
        public CeremonyMeetingsController(IAuthenticationService authenticationService, ICeremonyMeetingService ceremonyMeetingService,
            ICeremonyMeetingQuestionFileService ceremonyMeetingQuestionFileService)
        {
            this._authenticationService = authenticationService;
            this._ceremonyMeetingService = ceremonyMeetingService;
            this._ceremonyMeetingQuestionFileService = ceremonyMeetingQuestionFileService;
        }

        /// <summary>
        /// Gets the meeting with the specified ID.
        /// </summary>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <returns>The meeting with the specified ID.</returns>
        [HttpGet("{ceremonyId}/meetings/{meetingId}")]
        public async Task<ActionResult<CeremonyMeetingDTO>> Get(int meetingId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyMeetingService.GetCeremonyMeeting(meetingId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyMeetingNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotViewCeremonyDetailsException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Gets all the meetings for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The meetings for the specified ceremony.</returns>
        [HttpGet("{ceremonyId}/meetings")]
        public async Task<ActionResult<List<CeremonyMeetingDTO>>> GetAll(int ceremonyId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyMeetingService.GetCeremonyMeetings(ceremonyId, currentUserId.Value);
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
        /// Creates a new meeting.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="request">The meeting.</param>
        /// <returns>The newly created meeting.</returns>
        [HttpPost("{ceremonyId}/meetings")]
        public async Task<ActionResult<CeremonyMeetingDTO>> Create(int ceremonyId, CreateCeremonyMeetingRequest request)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyMeetingService.Create(request, ceremonyId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyTypeMeetingNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (CeremonyMeetingNotProvidedException)
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Updates the details of the specified meeting.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="request">The meeting.</param>
        [HttpPut("{ceremonyId}/meetings/{meetingId}")]
        public async Task<ActionResult> Update(int ceremonyId, int meetingId, UpdateCeremonyMeetingRequest request)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                await this._ceremonyMeetingService.Update(request, currentUserId.Value);

                return NoContent();
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyMeetingNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is CeremonyMeetingNotProvidedException)
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Updates the details of the specified question.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="request">The question.</param>
        [HttpPut("{ceremonyId}/meetings/{meetingId}/questions")]
        public async Task<ActionResult> UpdateQuestion(int ceremonyId, int meetingId, UpdateCeremonyMeetingQuestionRequest request)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                await this._ceremonyMeetingService.UpdateQuestion(request, meetingId, currentUserId.Value);

                return NoContent();
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyMeetingNotFoundException 
                || ex is CeremonyTypeMeetingQuestionNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is CeremonyMeetingQuestionNotProvidedException)
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        
        /// <summary>
        /// Adds a participant to a ceremony meeting.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="personId">The ID of the participant.</param>
        /// <returns>The newly created participant.</returns>
        [HttpPost("{ceremonyId}/meetings/{meetingId}/participants")]
        public async Task<ActionResult<PersonDTO>> CreateParticipant(int ceremonyId, int meetingId, int personId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyMeetingService.CreateParticipant(personId, meetingId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyMeetingNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is PersonAlreadyCeremonyMeetingParticipantException)
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }
        /// <summary>
        /// Deletes a participant from a ceremony meeting.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="personId">The ID of the participant.</param>
        [HttpDelete("{ceremonyId}/meetings/{meetingId}/participants")]
        public async Task<ActionResult> DeleteParticipant(int ceremonyId, int meetingId, int personId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                await this._ceremonyMeetingService.DeleteParticipant(personId, meetingId, currentUserId.Value);

                return NoContent();
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyMeetingNotFoundException || ex is CeremonyMeetingParticipantNotFoundException 
                || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Gets all the files for the specified ceremony meeting.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <returns>The files for the specified ceremony meeting.</returns>
        [HttpGet("{ceremonyId}/meetings/{meetingId}/files")]
        public async Task<ActionResult<List<CeremonyFileDTO>>> GetAllMeetingFiles(int ceremonyId, int meetingId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyMeetingQuestionFileService.GetMeetingFiles(meetingId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyMeetingNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotViewCeremonyDetailsException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Adds a file to a ceremony meeting question.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="meetingId">The ID of the meeting.</param>
        /// <param name="questionId">The ID of the question.</param>
        /// <param name="file">The file.</param>
        /// <returns>The newly created file.</returns>
        [HttpPost("{ceremonyId}/meetings/{meetingId}/questions/{questionId}/files")]
        public async Task<ActionResult<CeremonyFileDTO>> CreateQuestionFile(int ceremonyId, int meetingId, int questionId, [FromForm] CreateCeremonyMeetingQuestionFileRequest file)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyMeetingQuestionFileService.Create(file, questionId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyMeetingQuestionNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Deletes a file from a ceremony meeting question.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="participantId">The ID of the file.</param>
        [HttpDelete("{ceremonyId}/meetings/{meetingId}/questions/{questionId}/files/{fileId}")]
        public async Task<ActionResult> Delete(int ceremonyId, int meetingId, int questionId, int fileId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                await this._ceremonyMeetingQuestionFileService.Delete(fileId, currentUserId.Value);

                return NoContent();
            }
            catch (Exception ex) when (ex is CeremonyMeetingQuestionFileNotFoundException || ex is CeremonyFileNotFoundException 
                || ex is CelebrancyHQ.Models.Exceptions.Files.FileNotFoundException || ex is UserNotFoundException)
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