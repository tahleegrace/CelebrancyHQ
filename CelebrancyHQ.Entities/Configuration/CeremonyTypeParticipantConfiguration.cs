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
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.CelebrantForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.CelebrantCode,
                    Name = "Celebrant",
                    SortOrder = 1,
                    MinimumNumberOfParticipants = 1,
                    MaximumNumberOfParticipants = 1,
                    RequiresAddress = true,
                    RequiresPhoneNumber = true,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Celebrant (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.CelebrantForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.CelebrantCode,
                    Name = "Celebrant",
                    SortOrder = 1,
                    MinimumNumberOfParticipants = 1,
                    MaximumNumberOfParticipants = 1,
                    RequiresAddress = true,
                    RequiresPhoneNumber = true,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Couple.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.CoupleId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.CoupleCode,
                    Name = "Couple",
                    SortOrder = 2,
                    MinimumNumberOfParticipants = 2,
                    MaximumNumberOfParticipants = 2,
                    RequiresAddress = true,
                    RequiresPhoneNumber = true,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Organiser (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.OrganiserForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.OrganiserCode,
                    Name = "Organiser",
                    SortOrder = 3,
                    RequiresAddress = true,
                    RequiresPhoneNumber = true,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Organiser (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.OrganiserForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.OrganiserCode,
                    Name = "Organiser",
                    SortOrder = 3,
                    MinimumNumberOfParticipants = 1,
                    RequiresAddress = true,
                    RequiresPhoneNumber = true,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Witness.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.WitnessId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.WitnessCode,
                    Name = "Witness",
                    SortOrder = 4,
                    MinimumNumberOfParticipants = 2,
                    MaximumNumberOfParticipants = 2,
                    RequiresAddress = false,
                    RequiresPhoneNumber = false,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Bridal party.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.BridalPartyId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.BridalPartyCode,
                    Name = "Bridal party",
                    SortOrder = 5,
                    RequiresAddress = false,
                    RequiresPhoneNumber = false,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Invited guest (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.InvitedGuestForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.InvitedGuestCode,
                    Name = "Invited guest",
                    SortOrder = 7,
                    RequiresAddress = false,
                    RequiresPhoneNumber = false,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Deceased person.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.DeceasedPersonId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.DeceasedPersonCode,
                    Name = "Deceased person",
                    SortOrder = 2,
                    MinimumNumberOfParticipants = 1,
                    MaximumNumberOfParticipants = 1,
                    RequiresAddress = false,
                    RequiresPhoneNumber = false,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Invited guest (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.InvitedGuestForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.InvitedGuestCode,
                    Name = "Invited guest",
                    SortOrder = 6,
                    RequiresAddress = false,
                    RequiresPhoneNumber = false,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Other (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.OtherForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.OtherCode,
                    Name = "Other",
                    SortOrder = 8,
                    RequiresAddress = false,
                    RequiresPhoneNumber = false,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Other (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.OtherForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.OtherCode,
                    Name = "Other",
                    SortOrder = 7,
                    RequiresAddress = false,
                    RequiresPhoneNumber = false,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Interpreter (marriage).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.InterpreterForMarriageId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.InterpreterCode,
                    Name = "Interpreter",
                    SortOrder = 6,
                    MaximumNumberOfParticipants = 1,
                    RequiresAddress = false,
                    RequiresPhoneNumber = false,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Interpreter (funeral).
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.InterpreterForFuneralId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.InterpreterCode,
                    Name = "Interpreter",
                    SortOrder = 5,
                    MaximumNumberOfParticipants = 1,
                    RequiresAddress = false,
                    RequiresPhoneNumber = true,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Funeral director.
            builder.HasData
            (
                new CeremonyTypeParticipant()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeParticipantConstants.FuneralDirectorId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeParticipantConstants.FuneralDirectorCode,
                    Name = "Funeral director",
                    SortOrder = 4,
                    RequiresAddress = true,
                    RequiresPhoneNumber = true,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}