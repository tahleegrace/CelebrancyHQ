using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities.Configuration;

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
        /// The organisations table.
        /// </summary>
        public DbSet<Organisation> Organisations { get; set; }

        /// <summary>
        /// The ceremony types table.
        /// </summary>
        public DbSet<CeremonyType> CeremonyTypes { get; set; }

        /// <summary>
        /// The ceremony type participants table.
        /// </summary>
        public DbSet<CeremonyTypeParticipant> CeremonyTypeParticipants { get; set; }

        /// <summary>
        /// The ceremonies table.
        /// </summary>
        public DbSet<Ceremony> Ceremonies { get; set; }

        /// <summary>
        /// The ceremony participants table.
        /// </summary>
        public DbSet<CeremonyParticipant> CeremonyParticipants { get; set; }

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
        }
    }
}