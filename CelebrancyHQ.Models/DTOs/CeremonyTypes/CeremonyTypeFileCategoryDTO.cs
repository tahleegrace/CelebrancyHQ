namespace CelebrancyHQ.Models.DTOs.CeremonyTypes
{
    /// <summary>
    /// Stores details about a ceremony type file category.
    /// </summary>
    public class CeremonyTypeFileCategoryDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type file category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code of the ceremony type file category.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony type file category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony type file category.
        /// </summary>
        public string? Description { get; set; }
    }
}