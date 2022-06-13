using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.Organisations;
using CelebrancyHQ.Repository.Persons;
using CelebrancyHQ.Repository.Users;

namespace CelebrancyHQ.Repository
{
    /// <summary>
    /// Provides dependency setup for the CelebrancyHQ.Repository library.
    /// </summary>
    public static class DependencySetup
    {
        /// <summary>
        /// Sets up the dependencies for the CelebrancyHQ.Repository library.
        /// </summary>
        public static void AddCelebrancyHQRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonPhoneNumberRepository, PersonPhoneNumberRepository>();

            services.AddScoped<IOrganisationRepository, OrganisationRepository>();
            services.AddScoped<IOrganisationPhoneNumberRepository, OrganisationPhoneNumberRepository>();

            services.AddScoped<ICeremonyTypeRepository, CeremonyTypeRepository>();
            services.AddScoped<ICeremonyTypeParticipantRepository, CeremonyTypeParticipantRepository>();
            services.AddScoped<ICeremonyTypeDateRepository, CeremonyTypeDateRepository>();

            services.AddScoped<ICeremonyRepository, CeremonyRepository>();
            services.AddScoped<ICeremonyPermissionRepository, CeremonyPermissionRepository>();
            services.AddScoped<ICeremonyAuditLogRepository, CeremonyAuditLogRepository>();
            services.AddScoped<ICeremonyParticipantRepository, CeremonyParticipantRepository>();
            services.AddScoped<ICeremonyDateRepository, CeremonyDateRepository>();
            services.AddScoped<ICeremonyVenueRepository, CeremonyVenueRepository>();
        }
    }
}