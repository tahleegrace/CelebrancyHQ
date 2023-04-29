namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A type of form field.
    /// </summary>
    public class FormFieldType : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the form field type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code of the form field type.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description of the form field type.
        /// </summary>
        public string Description { get; set; }
    }
}