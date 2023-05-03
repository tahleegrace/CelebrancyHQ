namespace CelebrancyHQ.Entities
{
    public class CeremonyFormResponse : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony form response.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ceremony form.
        /// </summary>
        public CeremonyForm CeremonyForm { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony form.
        /// </summary>
        public int CeremonyFormId { get; set; }

        /// <summary>
        /// Gets or sets the ceremony type form field.
        /// </summary>
        public CeremonyTypeFormField CeremonyTypeFormField { get; set; }

        /// <summary>
        /// Gets or sets the ID of the ceremony type form field.
        /// </summary>
        public int CeremonyTypeFormFieldId { get; set; }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        public string? Response { get; set; }
    }
}