namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A section in a ceremony type form.
    /// </summary>
    public class CeremonyTypeFormSection : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type form section.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ceremony type form.
        /// </summary>
        public CeremonyTypeForm Form { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type form.
        /// </summary>
        public int FormId { get; set; }

        /// <summary>
        /// Gets or sets the name of the section.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the explanatory text for the section.
        /// </summary>
        public string? ExplanatoryText { get; set; }

        /// <summary>
        /// Gets or sets the number of columns in the section.
        /// </summary>
        public int NumberOfColumns { get; set; }

        /// <summary>
        /// Gets or sets the titles of the columns in the section.
        /// </summary>
        public string? ColumnTitles { get; set; }
    }
}