using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.Ceremonies;
using CelebrancyHQ.Services.CeremonyTypes;
using CelebrancyHQ.Services.Files;
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
            #region Authentication
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUniqueCodeGenerationService, UniqueCodeGenerationService>();
            #endregion

            #region Persons
            services.AddScoped<IPersonService, PersonService>();
            #endregion

            #region Files
            services.AddScoped<IFileService, FileService>();
            #endregion

            #region Ceremony Types
            services.AddScoped<ICeremonyTypePermissionService, CeremonyTypePermissionService>();
            services.AddScoped<ICeremonyTypeService, CeremonyTypeService>();
            services.AddScoped<ICeremonyTypeParticipantService, CeremonyTypeParticipantService>();
            services.AddScoped<ICeremonyTypeFormService, CeremonyTypeFormService>();
            #endregion

            #region Ceremonies
            services.AddScoped<ICeremonyPermissionService, CeremonyPermissionService>();
            services.AddScoped<ICeremonyService, CeremonyService>();
            services.AddScoped<ICeremonyDateService, CeremonyDateService>();
            services.AddScoped<ICeremonyParticipantService, CeremonyParticipantService>();
            services.AddScoped<ICeremonyServiceProviderService, CeremonyServiceProviderService>();
            services.AddScoped<ICeremonyMeetingService, CeremonyMeetingService>();
            services.AddScoped<ICeremonyMeetingQuestionFileService, CeremonyMeetingQuestionFileService>();
            services.AddScoped<ICeremonyFileService, CeremonyFileService>();
            #endregion
        }
    }
}