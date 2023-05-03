namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A form for a ceremony.
    /// </summary>
    public class CeremonyForm : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony form.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ceremony.
        /// </summary>
        public Ceremony Ceremony { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony.
        /// </summary>
        public int CeremonyId { get; set; }

        /// <summary>
        /// Gets or sets the ceremony type form.
        /// </summary>
        public CeremonyTypeForm CeremonyTypeForm { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type form.
        /// </summary>
        public int CeremonyTypeFormId { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony form.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony form.
        /// </summary>
        public string? Description { get; set; }
    }
}