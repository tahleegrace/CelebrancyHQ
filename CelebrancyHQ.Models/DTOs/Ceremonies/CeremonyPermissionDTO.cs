namespace CelebrancyHQ.Models.DTOs.Ceremonies
{
    /// <summary>
    /// Stores details about the permissions a user has for a particular ceremony.
    /// </summary>
    public class CeremonyPermissionDTO
    {
        /// <summary>
        /// Gets or sets the field that the permission is for.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets whether the participant can view the field.
        /// </summary>
        public bool CanView { get; set; } = false;

        /// <summary>
        /// Gets or sets whether the participant can edit the field.
        /// </summary>
        public bool CanEdit { get; set; } = false;

        /// <summary>
        /// Gets or sets whether the participant can edit the field with approval from other approvers.
        /// </summary>
        public bool CanEditWithApproval { get; set; } = false;

        /// <summary>
        /// Gets or sets whether the participant is an approver for this field.
        /// </summary>
        public bool IsApprover { get; set; } = false;

        /// <summary>
        /// Gets or sets whether the participant can view the history of this field.
        /// </summary>
        public bool CanViewHistory { get; set; } = false;
    }
}