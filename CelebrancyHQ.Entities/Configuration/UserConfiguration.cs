using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CelebrancyHQ.Entities.Constants;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the users table.
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
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}