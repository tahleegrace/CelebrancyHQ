using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using EntitiesConstants = CelebrancyHQ.Entities.Constants;
using CeremonyConstants = CelebrancyHQ.Constants.Ceremonies;

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
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeFileCategoryConstants.MarriageMeetingId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.MarriageCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeFileCategoryConstants.MeetingCode,
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
                    Id = EntitiesConstants.Ceremonies.CeremonyTypeFileCategoryConstants.FuneralMeetingId,
                    CeremonyTypeId = EntitiesConstants.Ceremonies.CeremonyTypeConstants.FuneralCeremonyId,
                    Code = CeremonyConstants.CeremonyTypeFileCategoryConstants.MeetingCode,
                    PermissionCode = "Meetings",
                    Name = "Meeting",
                    Description = "A meeting with another ceremony participant."
                }
            );
        }
    }
}