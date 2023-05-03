using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using CelebrancyHQ.Constants.CeremonyTypes;

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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.PhotographerForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.PhotographerCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.PhotographerForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.PhotographerCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.VideographerForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.VideographerCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.VideographerForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.VideographerCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.MusicianForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.MusicianCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.MusicianForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.MusicianCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.CatererForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.CatererCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.CatererForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.CatererCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.CalligrapherForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.CalligrapherCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.CalligrapherForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.CalligrapherCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.FloristForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.FloristCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.FloristForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.FloristCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeServiceProviderConstants.FuneralDirectorId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeServiceProviderConstants.FuneralDirectorCode,
                    Name = "Funeral Director",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}