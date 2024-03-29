﻿using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Organisations
{
    /// <summary>
    /// An organisations repository.
    /// </summary>
    public interface IOrganisationRepository
    {
        /// <summary>
        /// Finds the organisation with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the organisation.</param>
        /// <returns>The organisation with the specified ID.</returns>
        Task<Organisation?> FindById(int id);

        /// <summary>
        /// Finds the organisation with the specified name.
        /// </summary>
        /// <param name="name">The name of the organisation.</param>
        /// <returns>The organisation with the specified name.</returns>
        Task<Organisation?> FindByName(string name);

        /// <summary>
        /// Creates a new organisation.
        /// </summary>
        /// <param name="person">The organisation.</param>
        /// <returns>The newly created organisation.</returns>
        Task<Organisation> Create(Organisation organisation);

        /// <summary>
        /// Deletes the organisation with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the organisation.</param>
        Task Delete(int id);
    }
}