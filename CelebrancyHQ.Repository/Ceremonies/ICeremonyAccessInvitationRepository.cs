using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// A ceremony access invitation repository.
    /// </summary>
    public interface ICeremonyAccessInvitationRepository
    {
        /// <summary>
        /// Gets the ceremony access invitation with the specified ID.
        /// </summary>
        /// <param name="invitationId">The ID of the invitation.</param>
        /// <returns>The ceremony access invitation with the specified ID.</returns>
        Task<CeremonyAccessInvitation?> FindById(int invitationId);

        /// <summary>
        /// Gets whether a ceremony access invitation has been created for the specified user and ceremony.
        /// </summary>
        /// <param name="personId">The ID of the person.</param>
        /// <param name="ceremonyId">The ID of the ceremony.</param>
        /// <returns>Whether a ceremony access invitation has been created for the specified user and ceremony.</returns>
        Task<bool> PersonHasCeremonyAccessInvitation(int personId, int ceremonyId);

        /// <summary>
        /// Creates a new ceremony access invitation.
        /// </summary>
        /// <param name="invitation">The invitation.</param>
        /// <returns>The newly created ceremony access invitation.</returns>
        Task<CeremonyAccessInvitation> Create(CeremonyAccessInvitation invitation);
    }
}