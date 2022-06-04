using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the persons table.
    /// </summary>
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData
            (
                new Person()
                {
                    Id = 1,
                    FirstName = "CelebrancyHQ",
                    LastName = "System Administrator",
                    EmailAddress = "system.admin@celebrancyhq.co",
                    PreferredName = "System Administrator",
                    Title = "Mx",
                    Gender = "Other",
                    DateOfBirth = new DateTime(2022, 5, 9).ToUniversalTime(),
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );
        }
    }
}