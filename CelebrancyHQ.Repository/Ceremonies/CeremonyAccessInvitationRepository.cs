﻿using Microsoft.EntityFrameworkCore;

using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Ceremonies
{
    /// <summary>
    /// The ceremony access invitations repository.
    /// </summary>
    public class CeremonyAccessInvitationRepository : ICeremonyAccessInvitationRepository
    {
        private CelebrancyHQContext _context { get; set; }

        /// <summary>
        /// Creates a new instance of CeremonyAccessInvitiationRepository.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CeremonyAccessInvitationRepository(CelebrancyHQContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets the ceremony access invitation with the specified ID.
        /// </summary>
        /// <param name="invitationId">The ID of the invitation.</param>
        /// <returns>The ceremony access invitation with the specified ID.</returns>
        public async Task<CeremonyAccessInvitation?> FindById(int invitationId)
        {
            return await this._context.CeremonyAccessInvitations.Where(cai => cai.Id == invitationId && !cai.Deleted).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates a new ceremony access invitation.
        /// </summary>
        /// <param name="invitation">The invitation.</param>
        /// <returns>The newly created ceremony access invitation.</returns>
        public async Task<CeremonyAccessInvitation> Create(CeremonyAccessInvitation invitation)
        {
            invitation.Created = DateTime.UtcNow;
            invitation.Updated = DateTime.UtcNow;

            this._context.CeremonyAccessInvitations.Add(invitation);

            await this._context.SaveChangesAsync();

            var newInvitation = await FindById(invitation.Id);
            return newInvitation;
        }
    }
}