namespace CelebrancyHQ.Models.DTOs.Authentication
{
    /// <summary>
    /// Stores an email address and password for logging in to CelebrancyHQ.
    /// </summary>
    public class LoginDetailsDTO
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
