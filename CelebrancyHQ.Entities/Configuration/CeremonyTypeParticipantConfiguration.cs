using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CelebrancyHQ.Entities.Constants;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the ceremony type participants table.
    /// </summary>
    public class CeremonyTypeParticipantConfiguration : IEntityTypeConfiguration<CeremonyTypeParticipant>
    {
        public void Configure(EntityTypeBuilder<CeremonyTypeParticipant> builder)
        {
            // Celebrant (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.CelebrantForMarriageId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.CelebrantCode,
                    Name = "Celebrant",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Celebrant (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.CelebrantForFuneralId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.CelebrantCode,
                    Name = "Celebrant",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Couple.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.CoupleId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.CoupleCode,
                    Name = "Couple",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Organiser (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.OrganiserForMarriageId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.OrganiserCode,
                    Name = "Organiser",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Organiser (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.OrganiserForFuneralId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.OrganiserCode,
                    Name = "Organiser",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Witness.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.WitnessId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.WitnessCode,
                    Name = "Witness",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Bridal party.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.BridalPartyId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.BridalPartyCode,
                    Name = "Bridal party",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Invited guest (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.InvitedGuestForMarriageId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.InvitedGuestCode,
                    Name = "Invited guest",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Deceased person.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.DeceasedPersonId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.DeceasedPersonCode,
                    Name = "Deceased person",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Invited guest (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.InvitedGuestForFuneralId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.InvitedGuestCode,
                    Name = "Invited guest",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Other (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.OtherForMarriageId,
                    CeremonyTypeId = CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.OtherCode,
                    Name = "Other",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            // Other (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = CeremonyTypeParticipantConstants.OtherForFuneralId,
                    CeremonyTypeId = CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.OtherCode,
                    Name = "Other",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );
        }
    }
}