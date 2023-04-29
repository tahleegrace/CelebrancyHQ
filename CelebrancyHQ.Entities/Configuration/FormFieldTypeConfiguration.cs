using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using FormConstants = CelebrancyHQ.Constants.Forms;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the form field types table.
    /// </summary>
    public class FormFieldTypeConfiguration : IEntityTypeConfiguration<FormFieldType>
    {
        public void Configure(EntityTypeBuilder<FormFieldType> builder)
        {
            // Text field.
            builder.HasData
            (
                new FormFieldType()
                {
                    Id = EntitiesConstants.Forms.FormFieldTypeConstants.TextFieldId,
                    Code = FormConstants.FormFieldTypeConstants.TextFieldCode,
                    Description = "A field that can accept text or HTML data.",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Dropdown.
            builder.HasData
            (
                new FormFieldType()
                {
                    Id = EntitiesConstants.Forms.FormFieldTypeConstants.DropdownId,
                    Code = FormConstants.FormFieldTypeConstants.DropdownCode,
                    Description = "A field that allows the user to select one option from a list.",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Checkboxes.
            builder.HasData
            (
                new FormFieldType()
                {
                    Id = EntitiesConstants.Forms.FormFieldTypeConstants.CheckboxesId,
                    Code = FormConstants.FormFieldTypeConstants.CheckboxesCode,
                    Description = "A field that allows the user to select zero or more options from a row of checkboxes.",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Image.
            builder.HasData
            (
                new FormFieldType()
                {
                    Id = EntitiesConstants.Forms.FormFieldTypeConstants.ImageId,
                    Code = FormConstants.FormFieldTypeConstants.ImageCode,
                    Description = "A field that allows the user to select an image.",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // File.
            builder.HasData
            (
                new FormFieldType()
                {
                    Id = EntitiesConstants.Forms.FormFieldTypeConstants.FileId,
                    Code = FormConstants.FormFieldTypeConstants.FileCode,
                    Description = "A field that allows the user to select a file.",
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}