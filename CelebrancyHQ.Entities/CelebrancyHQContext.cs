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
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}