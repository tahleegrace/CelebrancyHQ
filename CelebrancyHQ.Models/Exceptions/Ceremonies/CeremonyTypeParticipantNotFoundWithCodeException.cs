namespace CelebrancyHQ.Models.Exceptions.Ceremonies
{
    /// <summary>
    /// An exception that occurs when a ceremony type participant is not found with the specified code.
    /// </summary>
    public class CeremonyTypeParticipantNotFoundWithCodeException : Exception
    {
        /// <summary>
        /// Gets the code of the participant.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Creates a new instance of CeremonyTypeParticipantNotFoundWithCodeException.
        /// </summary>
        /// <param name="code">The code of the participant.</param>
        public CeremonyTypeParticipantNotFoundWithCodeException(string code)
        {
            this.Code = code;
        }
    }
}