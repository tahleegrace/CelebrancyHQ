using System.Text;

namespace CelebrancyHQ.Services.Authentication
{
    /// <summary>
    /// A service that generates unique codes.
    /// </summary>
    public class UniqueCodeGenerationService : IUniqueCodeGenerationService
    {
        /// <summary>
        /// Generates a unique code.
        /// </summary>
        /// <param name="length">The length of the unique code.</param>
        public string GenerateUniqueCode(int length)
        {
            // SOURCE: Adapted from https://www.geeksforgeeks.org/c-sharp-randomly-generating-strings/
            var random = new Random();
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var randomValue = random.Next(0, 26);
                var letter = Convert.ToChar(randomValue + 65);

                builder.Append(letter);
            }

            return builder.ToString();
        }
    }
}