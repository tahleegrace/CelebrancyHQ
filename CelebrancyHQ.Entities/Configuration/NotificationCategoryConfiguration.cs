using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CelebrancyHQ.Constants.Notifications;
using EntitiesConstants = CelebrancyHQ.Entities.Constants;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the notification categories table.
    /// </summary>
    public class NotificationCategoryConfiguration : IEntityTypeConfiguration<NotificationCategory>
    {
        public void Configure(EntityTypeBuilder<NotificationCategory> builder)
        {
            // Ceremonies.
            builder.HasData
            (
                new NotificationCategory()
                {
                    Id = EntitiesConstants.Notifications.NotificationCategoryConstants.CeremoniesId,
                    Name = "Ceremonies",
                    Code = NotificationCategoryConstants.CeremoniesCode,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Ceremony types.
            builder.HasData
            (
                new NotificationCategory()
                {
                    Id = EntitiesConstants.Notifications.NotificationCategoryConstants.CeremonyTypesId,
                    Name = "Ceremony Types",
                    Code = NotificationCategoryConstants.CeremonyTypesCode,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Organisations.
            builder.HasData
            (
                new NotificationCategory()
                {
                    Id = EntitiesConstants.Notifications.NotificationCategoryConstants.OrganisationsId,
                    Name = "Organisations",
                    Code = NotificationCategoryConstants.OrganisationsCode,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Persons.
            builder.HasData
            (
                new NotificationCategory()
                {
                    Id = EntitiesConstants.Notifications.NotificationCategoryConstants.PersonsId,
                    Name = "Persons",
                    Code = NotificationCategoryConstants.PersonsCode,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Files.
            builder.HasData
            (
                new NotificationCategory()
                {
                    Id = EntitiesConstants.Notifications.NotificationCategoryConstants.FilesId,
                    Name = "Files",
                    Code = NotificationCategoryConstants.FilesCode,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );

            // Participant added to a ceremony.
            builder.HasData
            (
                new NotificationCategory()
                {
                    Id = EntitiesConstants.Notifications.CeremonyNotificationCategoryConstants.ParticipantAddedId,
                    Name = "Ceremonies",
                    Code = CeremonyNotificationCategoryConstants.ParticipantAddedCode,
                    Description = "A participant has been added to a ceremony",
                    ParentCategoryId = EntitiesConstants.Notifications.NotificationCategoryConstants.CeremoniesId,
                    Created = EntitiesConstants.GeneralConstants.SeedDataCreationDate,
                    Updated = EntitiesConstants.GeneralConstants.SeedDataCreationDate
                }
            );
        }
    }
}