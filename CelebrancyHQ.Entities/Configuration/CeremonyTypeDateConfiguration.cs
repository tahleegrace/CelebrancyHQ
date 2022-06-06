using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CelebrancyHQ.Entities.Constants;

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
                    Id = CeremonyTypeDateConstants.MarriageInitialPhoneCallId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.InitialPhoneCallCode,
                    Name = "Initial phone call",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Initial interview.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.MarriageInitialInterviewId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.InitialInterviewCode,
                    Name = "Initial interview",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Rehearsal.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.MarriageRehearsalId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.RehearsalCode,
                    Name = "Rehearsal",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Ceremony.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.MarriageCeremonyId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.CeremonyCode,
                    Name = "Ceremony",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Reception.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.MarriageReceptionId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.ReceptionCode,
                    Name = "Reception",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Other.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.MarriageOtherId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeDateConstants.OtherCode,
                    Name = "Other",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Funeral.

            // Initial phone call.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.FuneralInitialPhoneCallId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.InitialPhoneCallCode,
                    Name = "Initial phone call",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Initial interview.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.FuneralInitialInterviewId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.InitialInterviewCode,
                    Name = "Initial interview",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Rehearsal.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.FuneralRehearsalId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.RehearsalCode,
                    Name = "Rehearsal",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Ceremony.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.FuneralCeremonyId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.CeremonyCode,
                    Name = "Ceremony",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Wake.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.FuneralWakeId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.WakeCode,
                    Name = "Wake",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );

            // Other.
            builder.HasData
            (
                new CeremonyTypeDate()
                {
                    Id = CeremonyTypeDateConstants.FuneralOtherId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeDateConstants.OtherCode,
                    Name = "Other",
                    Created = GeneralConstants.SeedDataCreationDate,
                    Updated = GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}