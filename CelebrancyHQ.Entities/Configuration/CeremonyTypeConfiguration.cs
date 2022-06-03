using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the ceremony types table.
    /// </summary>
    public class CeremonyTypeConfiguration : IEntityTypeConfiguration<CeremonyType>
    {
        public void Configure(EntityTypeBuilder<CeremonyType> builder)
        {
            builder.HasData
            (
                new CeremonyType()
                {
                    Id = 1,
                    Name = "Marriage Ceremony",
                    Code = "Marriage",
                    Description = "A ceremony to celebrate the joining of two persons in marriage.",
                    Organisation = null,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            builder.HasData
            (
                new CeremonyType()
                {
                    Id = 2,
                    Name = "Funeral Ceremony",
                    Code = "Funeral",
                    Description = "A ceremony to celebrate the life of and remember a person who has recently passed way.",
                    Organisation = null,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );
        }
    }
}