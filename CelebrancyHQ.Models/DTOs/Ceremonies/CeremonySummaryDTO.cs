namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    public class CeremonySummaryDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date of the ceremony.
        /// </summary>
        public DateTime CeremonyDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the first venue the ceremony is hosted at.
        /// </summary>
        public string PrimaryVenueName { get; set; }

        /// <summary>
        /// Gets the address of the first venue the ceremony is hosted at.
        /// </summary>
        public string PrimaryAddress { get; set; }
    }
}