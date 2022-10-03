using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using CeremonyConstants = CelebrancyHQ.Constants.Ceremonies;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the ceremony type dates table.
    /// </summary>
    public class CeremonyTypeDateConfiguration : IEntityTypeConfiguration<CeremonyTypeDate>
    {
        public void Configure(EntityTypeBuilder<CeremonyTypeDate> builder)
        {
            // Marriage.

            // Initial phone call.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.MarriageInitialPhoneCallId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.InitialPhoneCallCode,
                    Name = "Initial phone call",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Initial interview.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.MarriageInitialInterviewId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.InitialInterviewCode,
                    Name = "Initial interview",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Rehearsal.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.MarriageRehearsalId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.RehearsalCode,
                    Name = "Rehearsal",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Ceremony.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.MarriageCeremonyId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.CeremonyCode,
                    Name = "Ceremony",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Reception.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.MarriageReceptionId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.ReceptionCode,
                    Name = "Reception",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Other.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.MarriageOtherId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.OtherCode,
                    Name = "Other",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Funeral.

            // Initial phone call.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.FuneralInitialPhoneCallId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.InitialPhoneCallCode,
                    Name = "Initial phone call",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Initial interview.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.FuneralInitialInterviewId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.InitialInterviewCode,
                    Name = "Initial interview",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Rehearsal.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.FuneralRehearsalId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.RehearsalCode,
                    Name = "Rehearsal",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Ceremony.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.FuneralCeremonyId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.CeremonyCode,
                    Name = "Ceremony",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Wake.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.FuneralWakeId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.WakeCode,
                    Name = "Wake",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Other.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.FuneralOtherId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.OtherCode,
                    Name = "Other",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Date of death.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeDateConstants.FuneralDateOfDeathId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.DateOfDeathCode,
                    Name = "Death",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}