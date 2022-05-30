namespace CelebrancyHQ.Models.DTOs.Users
{
    /// <summary>
    /// Stores details about a user.
    /// </summary>
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BusinessName { get; set; }

        public string EmailAddress { get; set; }
    }
}