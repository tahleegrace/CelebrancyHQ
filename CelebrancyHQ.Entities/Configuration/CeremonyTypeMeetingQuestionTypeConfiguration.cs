using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using CeremonyConstants = CelebrancyHQ.Constants.Ceremonies;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the ceremony type meeting question types table.
    /// </summary>
    public class CeremonyTypeMeetingQuestionTypeConfiguration : IEntityTypeConfiguration<CeremonyTypeMeetingQuestionType>
    {
        public void Configure(EntityTypeBuilder<CeremonyTypeMeetingQuestionType> builder)
        {
            // Text field.
            builder.HasData
            (
                new CeremonyTypeMeetingQuestionType()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeMeetingQuestionTypeConstants.TextFieldId,
                    Code = CeremonyConstants.CeremonyTypeMeetingQuestionTypeConstants.TextFieldCode,
                    Description = "A field that can accept text or HTML data.",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Dropdown.
            builder.HasData
            (
                new CeremonyTypeMeetingQuestionType()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeMeetingQuestionTypeConstants.DropdownId,
                    Code = CeremonyConstants.CeremonyTypeMeetingQuestionTypeConstants.DropdownCode,
                    Description = "A field that allows the user to select one option from a list.",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Checkboxes.
            builder.HasData
            (
                new CeremonyTypeMeetingQuestionType()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeMeetingQuestionTypeConstants.CheckboxesId,
                    Code = CeremonyConstants.CeremonyTypeMeetingQuestionTypeConstants.CheckboxesCode,
                    Description = "A field that allows the user to select zero or more options from a row of checkboxes.",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Image.
            builder.HasData
            (
                new CeremonyTypeMeetingQuestionType()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeMeetingQuestionTypeConstants.ImageId,
                    Code = CeremonyConstants.CeremonyTypeMeetingQuestionTypeConstants.ImageCode,
                    Description = "A field that allows the user to select an image.",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // File.
            builder.HasData
            (
                new CeremonyTypeMeetingQuestionType()
                {
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeMeetingQuestionTypeConstants.FileId,
                    Code = CeremonyConstants.CeremonyTypeMeetingQuestionTypeConstants.FileCode,
                    Description = "A field that allows the user to select a file.",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}