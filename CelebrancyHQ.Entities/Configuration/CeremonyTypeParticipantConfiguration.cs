using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using CeremonyConstants = CelebrancyHQ.Constants.Ceremonies;

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
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.CelebrantForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.CelebrantCode,
                    Name = "Celebrant",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Celebrant (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.CelebrantForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.CelebrantCode,
                    Name = "Celebrant",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Couple.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.CoupleId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.CoupleCode,
                    Name = "Couple",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Organiser (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.OrganiserForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.OrganiserCode,
                    Name = "Organiser",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Organiser (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.OrganiserForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.OrganiserCode,
                    Name = "Organiser",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Witness.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.WitnessId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.WitnessCode,
                    Name = "Witness",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Bridal party.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.BridalPartyId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.BridalPartyCode,
                    Name = "Bridal party",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Invited guest (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.InvitedGuestForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.InvitedGuestCode,
                    Name = "Invited guest",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Deceased person.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.DeceasedPersonId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.DeceasedPersonCode,
                    Name = "Deceased person",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Invited guest (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.InvitedGuestForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.InvitedGuestCode,
                    Name = "Invited guest",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Other (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.OtherForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.OtherCode,
                    Name = "Other",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Other (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.CeremonyTypeParticipantConstants.OtherForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.OtherCode,
                    Name = "Other",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}