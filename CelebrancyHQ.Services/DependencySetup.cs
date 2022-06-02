using CelebrancyHQ.Services.Authentication;
using CelebrancyHQ.Services.Ceremonies;

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
            services.AddScoped<ICeremonyTypeService, CeremonyTypeService>();
        }
    }
}