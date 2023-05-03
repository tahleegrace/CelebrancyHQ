using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CelebrancyHQ.Models.DTOs.Ceremonies;
using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.Ceremonies;
using CelebrancyHQ.Models.Exceptions.Users;
using CelebrancyHQ.Models.Exceptions.Ceremonies;
using CelebrancyHQ.Models.Exceptions.CeremonyTypes;

namespace CelebrancyHQ.API.Controllers
{
    /// <summary>
    /// Provides functionality for managing ceremony service providers.
    /// </summary>
    [Route("api/ceremonies")]
    [Authorize]
    [ApiController]
    public class CeremonyServiceProvidersController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICeremonyServiceProviderService _ceremonyServiceProviderService;

        /// <summary>
        /// Creates a new instance of CeremonyServiceProviderController.
        /// </summary>
        /// <param name="authenticationService">The authentication service.</param>
        /// <param name="ceremonyServiceProviderService">The ceremony service providers service.</param>
        public CeremonyServiceProvidersController(IAuthenticationService authenticationService, ICeremonyServiceProviderService ceremonyServiceProviderService)
        {
            this._authenticationService = authenticationService;
            this._ceremonyServiceProviderService = ceremonyServiceProviderService;
        }

        /// <summary>
        /// Creates a new service provider.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="request">The service provider.</param>
        /// <returns>The newly created service provider.</returns>
        [HttpPost("{ceremonyId}/service-providers")]
        public async Task<ActionResult<CeremonyServiceProviderDTO>> Create(int ceremonyId, CreateCeremonyServiceProviderRequest request)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                return await this._ceremonyServiceProviderService.Create(request, ceremonyId, currentUserId.Value);
            }
            catch (Exception ex) when (ex is CeremonyNotFoundException || ex is CeremonyTypeServiceProviderNotFoundWithCodeException || ex is UserNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) when (ex is CeremonyServiceProviderNotProvidedException || ex is OrganisationAlreadyCeremonyServiceProviderException)
            {
                return BadRequest();
            }
            catch (Exception ex) when (ex is PersonNotCeremonyParticipantException || ex is PersonCannotEditCeremonyException)
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Deletes a service provider.
        /// </summary>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <param name="serviceProviderId">The ID of the service provider.</param>
        [HttpDelete("{ceremonyId}/service-providers/{serviceProviderId}")]
        public async Task<ActionResult> Delete(int ceremonyId, int serviceProviderId)
        {
            var currentUserId = this._authenticationService.GetCurrentUserId(User);

            try
            {
                await this._ceremonyServiceProviderService.Delete(serviceProviderId, currentUserId.Value);

                return NoContent();
            }
            catch (Exception ex) when (ex is CeremonyServiceProviderNotFoundException || ex is UserNotFoundException)
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