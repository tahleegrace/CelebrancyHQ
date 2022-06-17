using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Auditing.Persons;

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
            services.AddScoped<IPersonAuditingService, PersonAuditingService>();
            services.AddScoped<IPersonPhoneNumberAuditingService, PersonPhoneNumberAuditingService>();

            services.AddScoped<ICeremonyAuditingService, CeremonyAuditingService>();
            services.AddScoped<ICeremonyDateAuditingService, CeremonyDateAuditingService>();
            services.AddScoped<ICeremonyParticipantAuditingService, CeremonyParticipantAuditingService>();
        }
    }
}