namespace CelebrancyHQ.Models.DTOs.CeremonyTypes
{
    /// <summary>
    /// A ceremony type form.
    /// </summary>
    public class CeremonyTypeFormDTO
    {
        /// <summary>
        /// Gets or sets the ID of the form.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the form.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the form.
        /// </summary>
        public string Description { get; set; }
    }
}