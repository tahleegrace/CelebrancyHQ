namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony type date is not found with the specified code.
    /// </summary>
    public class CeremonyTypeDateNotFoundWithCodeException : Exception
    {
        /// <summary>
        /// Gets the code of the date.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeDateNotFoundWithCodeException.
        /// </summary>
        /// <param name="code">The code of the date.</param>
        public CeremonyTypeDateNotFoundWithCodeException(string code)
        {
            this.Code = code;
        }
    }
}