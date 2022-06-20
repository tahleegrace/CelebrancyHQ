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
    /// Provides functionality for managing ceremony dates.
    /// </summary>
    [Route("api/ceremonies")]
    [Authorize]
    [ApiController]
    public class CeremonyDatesController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICeremonyDateService _ceremonyDateService;

        /// <summary>
        /// Creates a new instance of CeremonyDatesController.
        /// </summary>
        /// <param name="authenticationService">The authentication service.</param>
        /// <param name="ceremonyDateService">The ceremony dates service.</param>
        public CeremonyDatesController(IAuthenticationService authenticationService, ICeremonyDateService ceremonyDateService)
        {
            this._authenticationService = authenticationService;
            this._ceremonyDateService = ceremonyDateService;
        }

        /// <summary>
        /// Gets the dates for the ceremony for the specified ID.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The dates for the ceremony with the specified ID.</returns>
        [HttpGet("{ceremonyId}/dates")]
        public async Task<ActionResult<List<CeremonyDateDTO>>> GetDates(int ceremonyId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyDateService.GetDates(ceremonyId, currentUserId.Value);
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
        /// Creates a new date.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="request">The date.</param>
        /// <returns>The newly created date.</returns>
        [HttpPost("{ceremonyId}/dates")]
        public async Task<ActionResult<CeremonyDateDTO>> Create(int ceremonyId, CreateCeremonyDateRequest request)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyDateService.Create(request, ceremonyId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (CeremonyDateNotProvidedException)
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Updates the specified date.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="request">The date.</param>
        /// <returns>The newly updated date.</returns>
        [HttpPut("{ceremonyId}/dates")]
        public async Task<ActionResult<CeremonyDateDTO>> Update(int ceremonyId, UpdateCeremonyDateRequest request)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyDateService.Update(request, ceremonyId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyDateNotFoundException || ex is CeremonyTypeDateNotFoundWithCodeException
                || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is CeremonyDateNotProvidedException || ex is PersonAlreadyCeremonyParticipantException)
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