namespace CelebrancyHQ.Models.DTOs.CeremonyTypes
{
    /// <summary>
    /// A type of ceremony that can be offered (such as a wedding or funeral).
    /// </summary>
    public class CeremonyTypeDTO
    {
        /// <summary>
        /// Gets or sets the ID of the ceremony type.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the ceremony that can be offered.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the ceremony that can be offered.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets whether the ceremony can only be offered by the current organisation.
        /// </summary>
        public bool RestrictedToOrganisation { get; set; }
    }
}