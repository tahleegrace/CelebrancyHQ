using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Persons;

namespace CelebrancyHQ.API.Controllers
{
    /// <summary>
    /// Provides functionality for managing ceremony participants.
    /// </summary>
    [Route("api/ceremonies")]
    [Authorize]
    [ApiController]
    public class CeremonyParticipantsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICeremonyParticipantService _ceremonyParticipantService;

        /// <summary>
        /// Creates a new instance of CeremonyParticipantsController.
        /// </summary>
        /// <param name="authenticationService">The authentication service.</param>
        /// <param name="ceremonyParticipantService">The ceremony participants service.</param>
        public CeremonyParticipantsController(IAuthenticationService authenticationService, ICeremonyParticipantService ceremonyParticipantService)
        {
            this._authenticationService = authenticationService;
            this._ceremonyParticipantService = ceremonyParticipantService;
        }

        /// <summary>
        /// Gets all the participants (excluding invited guests) for the specified ceremony.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The participants for the specified ceremony.</returns>
        [HttpGet("{ceremonyId}/participants")]
        public async Task<ActionResult<List<CeremonyParticipantDTO>>> GetAll(int ceremonyId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyParticipantService.GetCeremonyParticipants(ceremonyId, currentUserId.Value);
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
        /// Creates a new participant.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="request">The participant.</param>
        /// <returns>The newly created participant.</returns>
        [HttpPost("{ceremonyId}/participants")]
        public async Task<ActionResult<CeremonyParticipantDTO>> Create(int ceremonyId, CreateCeremonyParticipantRequest request)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyParticipantService.Create(request, ceremonyId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyTypeParticipantNotFoundWithCodeException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is CeremonyParticipantNotProvidedException || ex is PersonAlreadyCeremonyParticipantException)
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Updates the details of the specified participant.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="participantId">The ID of the participant.</param>
        /// <param name="request">The participant.</param>
        [HttpPut("{ceremonyId}/participants/{participantId}")]
        public async Task<ActionResult> Update(int ceremonyId, int participantId, UpdateCeremonyParticipantRequest request)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                await this._ceremonyParticipantService.Update(request, currentUserId.Value);

                return NoContent();
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyParticipantNotFoundException || ex is UserNotFoundException || ex is PersonNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is CeremonyParticipantNotProvidedException || ex is PersonNotProvidedException || ex is PersonAlreadyExistsWithEmailAddressException)
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Deletes a participant.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="participantId">The ID of the participant.</param>
        [HttpDelete("{ceremonyId}/participants/{participantId}")]
        public async Task<ActionResult> Delete(int ceremonyId, int participantId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                await this._ceremonyParticipantService.Delete(participantId, currentUserId.Value);

                return NoContent();
            }
            catch (Exception ex) when (ex is CeremonyParticipantNotFoundException || ex is UserNotFoundException)
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