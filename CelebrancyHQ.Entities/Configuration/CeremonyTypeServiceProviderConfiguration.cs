using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using CeremonyConstants = CelebrancyHQ.Constants.Ceremonies;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the ceremony type service providers table.
    /// </summary>
    public class CeremonyTypeServiceProviderConfiguration : IEntityTypeConfiguration<CeremonyTypeServiceProvider>
    {
        public void Configure(EntityTypeBuilder<CeremonyTypeServiceProvider> builder)
        {
            // Photographer (marriage).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.PhotographerForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.PhotographerCode,
                    Name = "Photographer",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Photographer (funeral).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.PhotographerForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.PhotographerCode,
                    Name = "Photographer",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Videographer (marriage).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.VideographerForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.VideographerCode,
                    Name = "Videographer",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Videographer (funeral).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.VideographerForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.VideographerCode,
                    Name = "Videographer",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Musician (marriage).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.MusicianForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.MusicianCode,
                    Name = "Musician",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Musician (funeral).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.MusicianForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.MusicianCode,
                    Name = "Musician",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Caterer (marriage).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.CatererForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.CatererCode,
                    Name = "Caterer",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Caterer (funeral).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.CatererForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.CatererCode,
                    Name = "Caterer",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Calligrapher (marriage).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.CalligrapherForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.CalligrapherCode,
                    Name = "Calligrapher",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Calligrapher (funeral).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.CalligrapherForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.CalligrapherCode,
                    Name = "Calligrapher",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Florist (marriage).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.FloristForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.FloristCode,
                    Name = "Florist",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Florist (funeral).
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.FloristForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.FloristCode,
                    Name = "Florist",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Funeral director.
            builder.HasData
            (
                new CeremonyTypeServiceProvider()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeServiceProviderConstants.FuneralDirectorId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeServiceProviderConstants.FuneralDirectorCode,
                    Name = "Funeral Director",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}