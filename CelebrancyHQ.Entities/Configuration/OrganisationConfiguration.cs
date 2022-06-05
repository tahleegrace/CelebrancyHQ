using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CelebrancyHQ.Entities.Constants;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the organisations table.
    /// </summary>
    public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
    {
        public void Configure(EntityTypeBuilder<Organisation> builder)
        {
            builder.HasData
            (
                new Organisation()
                {
                    Id = 1,
                    Name = "CelebrancyHQ",
                    Type = "Celebrant",
                    EmailAddress = "info@celebrancyhq.co",
                    Website = "https://www.celebrancyhq.co",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}