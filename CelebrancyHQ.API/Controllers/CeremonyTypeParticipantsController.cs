using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CelebrancyHQ.Models.DTOs.CeremonyTypes;
using CelebrancyHQ.Models.Exceptions.CeremonyTypes;
using CelebrancyHQ.Services.CeremonyTypes;

namespace CelebrancyHQ.API.Controllers
{
    /// <summary>
    /// Provides functionality for managing the types of participants in a ceremony type.
    /// </summary>
    [Route("api/ceremony-types")]
    [Authorize]
    [ApiController]
    public class CeremonyTypeParticipantsController : ControllerBase
    {
        private readonly ICeremonyTypeParticipantService _ceremonyTypeParticipantService;

        /// <summary>
        /// Creates a new instance of CeremonyTypeParticipantsController.
        /// </summary>
        /// <param name="ceremonyTypeParticipantService">The ceremony type participants service.</param>
        public CeremonyTypeParticipantsController(ICeremonyTypeParticipantService ceremonyTypeParticipantService)
        {
            this._ceremonyTypeParticipantService = ceremonyTypeParticipantService;
        }

        /// <summary>
        /// Gets the ceremony type participants for the specified ceremony type.
        /// </summary>
        /// <param name="ceremonyTypeId">The ID of the ceremony type.</param>
        /// <param name="codeToExclude">The code of ceremony type participants to exclude.</param>
        /// <returns>The ceremony type participants for the specified ceremony type.</returns>
        [HttpGet("{ceremonyTypeId}/participants")]
        public async Task<ActionResult<List<CeremonyTypeParticipantDTO>>> GetAll(int ceremonyTypeId, string? codeToExclude)
        {
            try
            {
                return await this._ceremonyTypeParticipantService.GetCeremonyTypeParticipants(ceremonyTypeId, codeToExclude);
            }
            catch (CeremonyTypeNotFoundException)
            {
                return NotFound();
            }
        }
    }
}