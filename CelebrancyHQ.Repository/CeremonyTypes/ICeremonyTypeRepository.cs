﻿using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.CeremonyTypes
{
    /// <summary>
    /// A ceremony types repository.
    /// </summary>
    public interface ICeremonyTypeRepository
    {
        /// <summary>
        /// Finds the ceremony type with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the ceremony type.</param>
        /// <returns>The ceremony type with the specified ID.</returns>
        Task<CeremonyType?> FindById(int id);

        /// <summary>
        /// Finds the ceremony types that can be offered by the specified organisation.
        /// </summary>
        /// <param name="organisationId">The ID of the organisation.</param>
        /// <returns>The ceremony types that can be offered by the specified organisation.</returns>
        Task<List<CeremonyType>> FindByOrganisationId(int? organisationId);
    }
}