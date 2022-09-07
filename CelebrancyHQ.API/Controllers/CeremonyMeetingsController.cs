using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Models.Exceptions.Ceremonies;

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

        /// <summary>
        /// Creates a new instance of CeremonyMeetingsController.
        /// </summary>
        /// <param name="authenticationService">The authentication service.</param>
        /// <param name="ceremonyMeetingService">The ceremony meetings service.</param>
        public CeremonyMeetingsController(IAuthenticationService authenticationService, ICeremonyMeetingService ceremonyMeetingService)
        {
            this._authenticationService = authenticationService;
            this._ceremonyMeetingService = ceremonyMeetingService;
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
    }
}