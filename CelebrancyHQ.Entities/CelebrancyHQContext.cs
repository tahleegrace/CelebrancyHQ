using Microsoft.EntityFrameworkCore;

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

        public CelebrancyHQContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this._configuration.GetConnectionString("CelebrancyHQContext"));
        }
    }
}