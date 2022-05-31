using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Stores additional users database configuration.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User() // TODO: Use a proper hashed password with salt here.
                {
                    Id = 1,
                    EmailAddress = "system.admin@celebrancyhq.co",
                    PasswordHash = "testpassword",
                    PasswordSalt = "passwordsalt",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );
        }
    }
}