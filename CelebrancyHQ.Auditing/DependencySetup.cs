﻿using CelebrancyHQ.Auditing.Ceremonies;
using CelebrancyHQ.Auditing.Files;
using CelebrancyHQ.Auditing.Organisations;
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
            services.AddScoped<IPersonAddressAuditingService, PersonAddressAuditingService>();

            services.AddScoped<IOrganisationAuditingService, OrganisationAuditingService>();
            services.AddScoped<IOrganisationPhoneNumberAuditingService, OrganisationPhoneNumberAuditingService>();
            services.AddScoped<IOrganisationAddressAuditingService, OrganisationAddressAuditingService>();

            services.AddScoped<IFileAuditingService, FileAuditingService>();

            services.AddScoped<ICeremonyAuditingService, CeremonyAuditingService>();
            services.AddScoped<ICeremonyDateAuditingService, CeremonyDateAuditingService>();
            services.AddScoped<ICeremonyParticipantAuditingService, CeremonyParticipantAuditingService>();
            services.AddScoped<ICeremonyServiceProviderAuditingService, CeremonyServiceProviderAuditingService>();
            services.AddScoped<ICeremonyFileAuditingService, CeremonyFileAuditingService>();
            services.AddScoped<ICeremonyMeetingAuditingService, CeremonyMeetingAuditingService>();
            services.AddScoped<ICeremonyMeetingParticipantAuditingService, CeremonyMeetingParticipantAuditingService>();
            services.AddScoped<ICeremonyMeetingQuestionAuditingService, CeremonyMeetingQuestionAuditingService>();
            services.AddScoped<ICeremonyMeetingQuestionFileAuditingService, CeremonyMeetingQuestionFileAuditingService>();
        }
    }
}