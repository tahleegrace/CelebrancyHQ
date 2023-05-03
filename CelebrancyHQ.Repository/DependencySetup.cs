using CelebrancyHQ.Repository.Addresses;
using CelebrancyHQ.Repository.Ceremonies;
using CelebrancyHQ.Repository.CeremonyTypes;
using CelebrancyHQ.Repository.Files;
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
            #region Users
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Persons
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonAuditLogRepository, PersonAuditLogRepository>();
            services.AddScoped<IPersonPhoneNumberRepository, PersonPhoneNumberRepository>();
            #endregion

            #region Organisations
            services.AddScoped<IOrganisationRepository, OrganisationRepository>();
            services.AddScoped<IOrganisationAuditLogRepository, OrganisationAuditLogRepository>();
            services.AddScoped<IOrganisationPhoneNumberRepository, OrganisationPhoneNumberRepository>();
            #endregion

            #region Addresses
            services.AddScoped<IAddressRepository, AddressRepository>();
            #endregion

            #region Files
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IFileAuditLogRepository, FileAuditLogRepository>();
            #endregion

            #region Ceremony Types
            services.AddScoped<ICeremonyTypeRepository, CeremonyTypeRepository>();
            services.AddScoped<ICeremonyTypeParticipantRepository, CeremonyTypeParticipantRepository>();
            services.AddScoped<ICeremonyTypeDateRepository, CeremonyTypeDateRepository>();
            services.AddScoped<ICeremonyTypeServiceProviderRepository, CeremonyTypeServiceProviderRepository>();

            services.AddScoped<ICeremonyTypeMeetingRepository, CeremonyTypeMeetingRepository>();
            services.AddScoped<ICeremonyTypeMeetingQuestionRepository, CeremonyTypeMeetingQuestionRepository>();
            services.AddScoped<ICeremonyTypeFileCategoryRepository, CeremonyTypeFileCategoryRepository>();

            services.AddScoped<ICeremonyTypeFormRepository, CeremonyTypeFormRepository>();
            #endregion

            #region Ceremonies
            services.AddScoped<ICeremonyRepository, CeremonyRepository>();
            services.AddScoped<ICeremonyPermissionRepository, CeremonyPermissionRepository>();
            services.AddScoped<ICeremonyAccessInvitationRepository, CeremonyAccessInvitationRepository>();
            services.AddScoped<ICeremonyAuditLogRepository, CeremonyAuditLogRepository>();
            services.AddScoped<ICeremonyParticipantRepository, CeremonyParticipantRepository>();
            services.AddScoped<ICeremonyDateRepository, CeremonyDateRepository>();
            services.AddScoped<ICeremonyVenueRepository, CeremonyVenueRepository>();
            services.AddScoped<ICeremonyServiceProviderRepository, CeremonyServiceProviderRepository>();
            services.AddScoped<ICeremonyMeetingRepository, CeremonyMeetingRepository>();
            services.AddScoped<ICeremonyMeetingQuestionRepository, CeremonyMeetingQuestionRepository>();
            services.AddScoped<ICeremonyMeetingParticipantRepository, CeremonyMeetingParticipantRepository>();
            services.AddScoped<ICeremonyMeetingQuestionFileRepository, CeremonyMeetingQuestionFileRepository>();
            services.AddScoped<ICeremonyFileRepository, CeremonyFileRepository>();
            #endregion
        }
    }
}