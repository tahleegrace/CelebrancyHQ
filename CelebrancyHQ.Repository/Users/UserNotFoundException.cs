namespace CelebrancyHQ.Repository.Users
{
    /// <summary>
    /// An exception that occurs when a user is not found.
    /// </summary>
    public class UserNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public int UserId { get; }

        /// <summary>
        /// Creates a new instance of UserNotFoundException.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public UserNotFoundException(int userId)
            : base()
        {
            this.UserId = userId;
        }
    }
}