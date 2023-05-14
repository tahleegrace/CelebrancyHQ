namespace CelebrancyHQ.Entities
{
    /// <summary>
    /// A notification category.
    /// </summary>
    public class NotificationCategory : BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the notification category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the notification category.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the notification category.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description of the notification category.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the parent category.
        /// </summary>
        public NotificationCategory? ParentCategory { get; set; }

        /// <summary>
        /// Gets or sets the ID of the parent category.
        /// </summary>
        public int? ParentCategoryId { get; set; }
    }
}