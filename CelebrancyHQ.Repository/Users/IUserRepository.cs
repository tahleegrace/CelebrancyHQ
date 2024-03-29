﻿using CelebrancyHQ.Entities;

namespace CelebrancyHQ.Repository.Users
{
    /// <summary>
    /// A users repository.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Finds the user with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user with the specified ID.</returns>
        Task<User?> FindById(int id);

        /// <summary>
        /// Finds the user with the specified email address.
        /// </summary>
        /// <param name="emailAddress">The email address of the user.</param>
        /// <returns>The user with the specified email address.</returns>
        Task<User?> FindByEmailAddress(string emailAddress);
    }
}