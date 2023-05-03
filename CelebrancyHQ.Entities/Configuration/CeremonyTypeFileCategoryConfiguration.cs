using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using CelebrancyHQ.Constants.CeremonyTypes;

namespace CelebrancyHQ.Entities.Configuration
{
    /// <summary>
    /// Sets up seed data for the ceremony type file categories table.
    /// </summary>
    public class CeremonyTypeFileCategoryConfiguration : IEntityTypeConfiguration<CeremonyTypeFileCategory>
    {
        public void Configure(EntityTypeBuilder<CeremonyTypeFileCategory> builder)
        {
            // Meeting (marriage).
            builder.HasData
            (
                new CeremonyTypeFileCategory()
                {
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeFileCategoryConstants.MarriageMeetingId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyTypeFileCategoryConstants.MeetingCode,
                    PermissionCode = "Meetings",
                    Name = "Meeting",
                    Description = "A meeting with another ceremony participant."
                }
            );

            // Meeting (funeral).
            builder.HasData
            (
                new CeremonyTypeFileCategory()
                {
                    Id = EntitiesConstants.CeremonyTypes.CeremonyTypeFileCategoryConstants.FuneralMeetingId,
                    CeremonyTypeId = EntitiesConstants.CeremonyTypes.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyTypeFileCategoryConstants.MeetingCode,
                    PermissionCode = "Meetings",
                    Name = "Meeting",
                    Description = "A meeting with another ceremony participant."
                }
            );
        }
    }
}