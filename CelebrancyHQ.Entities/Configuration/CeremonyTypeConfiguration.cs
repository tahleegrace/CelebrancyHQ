using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using CelebrancyHQ.Constants.CeremonyTypes;

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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Name = "Marriage Ceremony",
                    Code = CeremonyTypeConstants.MarriageCeremonyCode,
                    Description = "A ceremony to celebrate the joining of two persons in marriage.",
                    Organisation = null,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            builder.HasData
            (
                new CeremonyType()
                {
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Name = "Funeral Ceremony",
                    Code = CeremonyTypeConstants.FuneralCeremonyCode,
                    Description = "A ceremony to celebrate the life of and remember a person who has recently passed way.",
                    Organisation = null,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}