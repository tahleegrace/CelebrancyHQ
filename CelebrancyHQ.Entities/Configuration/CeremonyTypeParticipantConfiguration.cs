using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using CeremonyConstants = CelebrancyHQ.Constants.Ceremonies;
using CelebrancyHQ.Constants.CeremonyTypes;

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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.CelebrantForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.CelebrantCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.CelebrantForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.CelebrantCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.CoupleId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.CoupleCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.OrganiserForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.OrganiserCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.OrganiserForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.OrganiserCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.WitnessId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.WitnessCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.BridalPartyId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.BridalPartyCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.InvitedGuestForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.InvitedGuestCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.DeceasedPersonId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.DeceasedPersonCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.InvitedGuestForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.InvitedGuestCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.OtherForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.OtherCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.OtherForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.OtherCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.InterpreterForMarriageId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeParticipantConstants.InterpreterCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.InterpreterForFuneralId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.InterpreterCode,
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
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeParticipantConstants.FuneralDirectorId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeParticipantConstants.FuneralDirectorCode,
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