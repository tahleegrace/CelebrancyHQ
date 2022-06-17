using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// An entity in CelebrancyHQ.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// The date the entity was created.
        /// </summary>
        [JsonIgnore]
        public DateTime Created { get; set; }

        /// <summary>
        /// The date the entity was last modified.
        /// </summary>
        [JsonIgnore]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets whether the entity has been deleted.
        /// </summary>
        [Required]
        [JsonIgnore]
        public bool Deleted { get; set; } = false;
    }
}