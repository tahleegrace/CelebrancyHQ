using CelebrancyHQ.Auditing.Ceremonies;

namespace CelebrancyHQ.Auditing
{
    /// <summary>
    /// Provides dependency setup for the CelebrancyHQ.Auditing library.
    /// </summary>
    public static class DependencySetup
    {
        /// <summary>
        /// Sets up the dependencies for the CelebrancyHQ.Auditing library.
        /// </summary>
        public static void AddCelebrancyHQAuditingServices(this IServiceCollection services)
        {
            services.AddScoped<ICeremonyAuditingService, CeremonyAuditingService>();
            services.AddScoped<ICeremonyDateAuditingService, CeremonyDateAuditingService>();
        }
    }
}