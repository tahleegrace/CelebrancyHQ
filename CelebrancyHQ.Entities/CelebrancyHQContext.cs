using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities.Configuration;
using CelebrancyHQ.Entities.Auditing;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// The CelebrancyHQ database context.
    /// </summary>
    public class CelebrancyHQContext : DbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// The users table.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// The persons table.
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// The person audit logs table.
        /// </summary>
        public DbSet<PersonAuditLog> PersonAuditLogs { get; set; }

        /// <summary>
        /// The files table.
        /// </summary>
        public DbSet<File> Files { get; set; }

        /// <summary>
        /// The file audit logs table.
        /// </summary>
        public DbSet<FileAuditLog> FileAuditLogs { get; set; }

        /// <summary>
        /// The person phone numbers table.
        /// </summary>
        public DbSet<PersonPhoneNumber> PersonPhoneNumbers { get; set; }

        /// <summary>
        /// The addresses table.
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// The organisations table.
        /// </summary>
        public DbSet<Organisation> Organisations { get; set; }

        /// <summary>
        /// The organisation audit logs table.
        /// </summary>
        public DbSet<OrganisationAuditLog> OrganisationAuditLogs { get; set; }

        /// <summary>
        /// The organisation phone numbers table.
        /// </summary>
        public DbSet<OrganisationPhoneNumber> OrganisationPhoneNumbers { get; set; }

        /// <summary>
        /// The ceremony types table.
        /// </summary>
        public DbSet<CeremonyType> CeremonyTypes { get; set; }

        /// <summary>
        /// The ceremony type participants table.
        /// </summary>
        public DbSet<CeremonyTypeParticipant> CeremonyTypeParticipants { get; set; }

        /// <summary>
        /// The ceremony type dates table.
        /// </summary>
        public DbSet<CeremonyTypeDate> CeremonyTypeDates { get; set; }

        /// <summary>
        /// The ceremony type service providers table.
        /// </summary>
        public DbSet<CeremonyTypeServiceProvider> CeremonyTypeServiceProviders { get; set; }

        /// <summary>
        /// The ceremony type meetings table.
        /// </summary>
        public DbSet<CeremonyTypeMeeting> CeremonyTypeMeetings { get; set; }

        /// <summary>
        /// The ceremony type meeting question types table.
        /// </summary>
        public DbSet<CeremonyTypeMeetingQuestionType> CeremonyTypeMeetingQuestionTypes { get; set; }

        /// <summary>
        /// The ceremony type meeting questions table.
        /// </summary>
        public DbSet<CeremonyTypeMeetingQuestion> CeremonyTypeMeetingQuestions { get; set; }

        /// <summary>
        /// The ceremony type file categories table.
        /// </summary>
        public DbSet<CeremonyTypeFileCategory> CeremonyTypeFileCategories { get; set; }

        /// <summary>
        /// The ceremony type forms table.
        /// </summary>
        public DbSet<CeremonyTypeForm> CeremonyTypeForms { get; set; }

        /// <summary>
        /// The ceremony type form sections table.
        /// </summary>
        public DbSet<CeremonyTypeFormSection> CeremonyTypeFormSections { get; set; }

        /// <summary>
        /// The ceremonies table.
        /// </summary>
        public DbSet<Ceremony> Ceremonies { get; set; }

        /// <summary>
        /// The ceremony audit logs table.
        /// </summary>
        public DbSet<CeremonyAuditLog> CeremonyAuditLogs { get; set; }

        /// <summary>
        /// The ceremony permissions table.
        /// </summary>
        public DbSet<CeremonyPermission> CeremonyPermissions { get; set; }

        /// <summary>
        /// The ceremony participants table.
        /// </summary>
        public DbSet<CeremonyParticipant> CeremonyParticipants { get; set; }

        /// <summary>
        /// The ceremony service providers table.
        /// </summary>
        public DbSet<CeremonyServiceProvider> CeremonyServiceProviders { get; set; }

        /// <summary>
        /// The ceremony access invitations table.
        /// </summary>
        public DbSet<CeremonyAccessInvitation> CeremonyAccessInvitations { get; set; }

        /// <summary>
        /// The ceremony venues table.
        /// </summary>
        public DbSet<CeremonyVenue> CeremonyVenues { get; set; }

        /// <summary>
        /// The ceremony dates table.
        /// </summary>
        public DbSet<CeremonyDate> CeremonyDates { get; set; }

        /// <summary>
        /// The ceremony files table.
        /// </summary>
        public DbSet<CeremonyFile> CeremonyFiles { get; set; }

        /// <summary>
        /// The ceremony meetings table.
        /// </summary>
        public DbSet<CeremonyMeeting> CeremonyMeetings { get; set; }

        /// <summary>
        /// The ceremony meeting questions table.
        /// </summary>
        public DbSet<CeremonyMeetingQuestion> CeremonyMeetingQuestions { get; set; }

        /// <summary>
        /// The ceremony meeting question files table.
        /// </summary>
        public DbSet<CeremonyMeetingQuestionFile> CeremonyMeetingQuestionFiles { get; set; }

        /// <summary>
        /// The ceremony meeting participants table.
        /// </summary>
        public DbSet<CeremonyMeetingParticipant> CeremonyMeetingParticipants { get; set; }

        /// <summary>
        /// Creates a new instance of CelebrancyHQContext.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public CelebrancyHQContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this._configuration.GetConnectionString("CelebrancyHQContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrganisationConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CeremonyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CeremonyTypeParticipantConfiguration());
            modelBuilder.ApplyConfiguration(new CeremonyTypeDateConfiguration());
            modelBuilder.ApplyConfiguration(new CeremonyTypeServiceProviderConfiguration());
            modelBuilder.ApplyConfiguration(new CeremonyTypeMeetingQuestionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CeremonyTypeFileCategoryConfiguration());
        }
    }
}