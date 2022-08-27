using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.Ceremonies;
using CelebrancyHQ.Services.Persons;

namespace CelebrancyHQ.Services
{
    /// <summary>
    /// Provides dependency setup for the CelebrancyHQ.Services library.
    /// </summary>
    public static class DependencySetup
    {
        /// <summary>
        /// Sets up the dependencies for the CelebrancyHQ.Services library.
        /// </summary>
        public static void AddCelebrancyHQServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUniqueCodeGenerationService, UniqueCodeGenerationService>();

            services.AddScoped<IPersonService, PersonService>();

            services.AddScoped<ICeremonyTypeService, CeremonyTypeService>();
            services.AddScoped<ICeremonyTypeParticipantService, CeremonyTypeParticipantService>();

            services.AddScoped<ICeremonyHelpers, CeremonyHelpers>();
            services.AddScoped<ICeremonyService, CeremonyService>();
            services.AddScoped<ICeremonyDateService, CeremonyDateService>();
            services.AddScoped<ICeremonyParticipantService, CeremonyParticipantService>();
            services.AddScoped<ICeremonyServiceProviderService, CeremonyServiceProviderService>();
            services.AddScoped<ICeremonyMeetingService, CeremonyMeetingService>();
        }
    }
}