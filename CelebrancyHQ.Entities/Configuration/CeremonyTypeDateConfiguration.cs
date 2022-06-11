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
            // TODO: Add date of death date type here.

            // Marriage.

            // Initial phone call.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = EntitiesConstants.CeremonyTypeDateConstants.MarriageInitialPhoneCallId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.MarriageInitialInterviewId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.MarriageRehearsalId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.MarriageCeremonyId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.MarriageReceptionId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.MarriageOtherId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.FuneralInitialPhoneCallId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.FuneralInitialInterviewId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.FuneralRehearsalId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.FuneralCeremonyId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.FuneralWakeId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
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
                    Id = EntitiesConstants.CeremonyTypeDateConstants.FuneralOtherId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeDateConstants.OtherCode,
                    Name = "Other",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}