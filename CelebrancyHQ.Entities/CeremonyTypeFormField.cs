namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A field within a ceremony type form.
    /// </summary>
    public class CeremonyTypeFormField : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the form field.
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
        /// Gets or sets the ceremony type form section.
        /// </summary>
        public CeremonyTypeFormSection Section { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type form section.
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// Get or sets the form field type.
        /// </summary>
        public FormFieldType FormFieldType { get; set; }

        /// <summary>
        /// Gets or sets the ID of the form field type.
        /// </summary>
        public int FormFieldTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the form field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the explanatory text for the form field.
        /// </summary>
        public string? ExplanatoryText { get; set; }

        /// <summary>
        /// Gets or sets a comma-separated list of the options available for the form field (only applicable for dropdown and checkbox form field types).
        /// </summary>
        public string? Options { get; set; }

        /// <summary>
        /// Gets or sets whether the form field is required.
        /// </summary>
        public bool Required { get; set; }
    }
}