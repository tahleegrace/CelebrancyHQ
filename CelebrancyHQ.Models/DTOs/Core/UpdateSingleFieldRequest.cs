namespace CelebrancyHQ.Models.DTOs.Core
{
    /// <summary>
    /// A request for updating a single field 
    /// </summary>
    /// <typeparam name="FieldType">The type of field that is being updated.</typeparam>
    public class UpdateSingleFieldRequest<FieldType>
    {
        /// <summary>
        /// Gets or sets the value of the field.
        /// </summary>
        public FieldType Value { get; set; }

        /// <summary>
        /// Gets or sets whether the field has been updated.
        /// </summary>
        public bool Updated { get; set; }
    }
}