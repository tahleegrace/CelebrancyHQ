using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using CelebrancyHQ.Constants.CeremonyTypes;

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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.MarriageInitialPhoneCallId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.InitialPhoneCallCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.MarriageInitialInterviewId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.InitialInterviewCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.MarriageRehearsalId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.RehearsalCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.MarriageCeremonyId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.CeremonyCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.MarriageReceptionId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.ReceptionCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.MarriageOtherId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.OtherCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.FuneralInitialPhoneCallId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.InitialPhoneCallCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.FuneralInitialInterviewId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.InitialInterviewCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.FuneralRehearsalId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.RehearsalCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.FuneralCeremonyId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.CeremonyCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.FuneralWakeId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.WakeCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.FuneralOtherId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.OtherCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeDateConstants.FuneralDateOfDeathId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.DateOfDeathCode,
                    Name = "Death",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}