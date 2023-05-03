using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CelebrancyHQ.Models.DTOs.CeremonyTypes;
using CelebrancyHQ.Models.Exceptions.CeremonyTypes;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.CeremonyTypes;

namespace CelebrancyHQ.API.Controllers
{
    /// <summary>
    /// Provides functionality for managing ceremony type meetings.
    /// </summary>
    [Route("api/ceremony-types")]
    [Authorize]
    [ApiController]
    public class CeremonyTypeFormsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICeremonyTypeFormService _ceremonyTypeFormService;

        /// <summary>
        /// Creates a new instance of CeremonyTypeFormsController.
        /// </summary>
        /// <param name="authenticationService">The authentication service.</param>
        /// <param name="ceremonyTypeFormService">The ceremony type forms service.</param>
        public CeremonyTypeFormsController(IAuthenticationService authenticationService, ICeremonyTypeFormService ceremonyTypeFormService)
        {
            this._authenticationService = authenticationService;
            this._ceremonyTypeFormService = ceremonyTypeFormService;
        }

        /// <summary>
        /// Gets the ceremony type form with the specified ID.
        /// </summary>
        /// <param name="formId">The ID of the form.</param>
        /// <returns>The ceremony type form with the specified ID.</returns>
        [HttpGet("{ceremonyTypeId}/forms/{formId}")]
        public async Task<ActionResult<CeremonyTypeFormDTO>> Get(int formId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyTypeFormService.GetCeremonyTypeForm(formId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyTypeFormNotFoundException || ex is CeremonyTypeNotFoundException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is PersonCannotViewCeremonyTypeDetailsException)
            {
                return Forbid();
            }
        }
    }
}