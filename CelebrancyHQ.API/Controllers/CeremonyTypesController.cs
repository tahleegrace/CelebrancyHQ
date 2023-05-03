using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Models.DTOs.CeremonyTypes;
using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.CeremonyTypes;

namespace CelebrancyHQ.API.Controllers
{
    /// <summary>
    /// Provides functionality for managing the types of ceremonies someone can offer.
    /// </summary>
    [Route("api/ceremony-types")]
    [Authorize]
    [ApiController]
    public class CeremonyTypesController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICeremonyTypeService _ceremonyTypeService;

        /// <summary>
        /// Creates a new instance of CeremonyTypesController.
        /// </summary>
        /// <param name="authenticationService">The authenticatio</param>
        /// <param name="ceremonyTypeService">The ceremony types service.</param>
        public CeremonyTypesController(IAuthenticationService authenticationService, ICeremonyTypeService ceremonyTypeService)
        {
            this._authenticationService = authenticationService;
            this._ceremonyTypeService = ceremonyTypeService;
        }

        /// <summary>
        /// Gets the ceremony types that can be offered by the current user.
        /// </summary>
        /// <returns>The ceremony types that can be offered by the currnet user.</returns>
        [HttpGet]
        public async Task<ActionResult<List<CeremonyTypeDTO>>> GetAll()
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyTypeService.GetCeremonyTypes(currentUserId.Value);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }
    }
}