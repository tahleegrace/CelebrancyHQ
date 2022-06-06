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
    /// Provides functionality for managing ceremonies.
    /// </summary>
    [Route("api/ceremonies")]
    [Authorize]
    [ApiController]
    public class CeremoniesControlller : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICeremonyService _ceremoniesService;

        /// <summary>
        /// Creates a new instance of CeremoniesController.
        /// </summary>
        /// <param name="authenticationService">The authentication service.</param>
        /// <param name="ceremoniesService">The ceremonies service.</param>
        public CeremoniesControlller(IAuthenticationService authenticationService, ICeremonyService ceremoniesService)
        {
            this._authenticationService = authenticationService;
            this._ceremoniesService = ceremoniesService;
        }

        /// <summary>
        /// Gets all the ceremonies where the current user has the specified participant type between the specified dates.
        /// </summary>
        /// <param name="participantTypeCode">The participant type.</param>
        /// <param name="from">The from date.</param>
        /// <param name="to">The to date.</param>
        /// <returns>The ceremonies matching the specified criteria.</returns>
        [HttpGet("{participantTypeCode}")]
        public async Task<ActionResult<List<CeremonySummaryDTO>>> GetAll(string participantTypeCode, DateTime? from, DateTime? to)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremoniesService.GetAll(currentUserId.Value, participantTypeCode, from, to);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Gets the key details of the ceremony with the specified ID.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>The key details of the ceremony with the specified ID.</returns>
        [HttpGet("{ceremonyId}/key-details")]
        public async Task<ActionResult<CeremonyKeyDetailsDTO>> GetKeyDetailsById(int ceremonyId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremoniesService.GetCeremonyKeyDetails(ceremonyId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (UserNotCeremonyParticipantException)
            {
                return Forbid();
            }
        }
    }
}