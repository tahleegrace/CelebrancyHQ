namespace CelebrancyHQ.Entities.Constants
{
    /// <summary>
    /// Constants specific to ceremony type participants.
    /// </summary>
    public static class CeremonyTypeParticipantConstants
    {
        // Celebrant (marriage).
        public const int CelebrantForMarriageId = 1;
        public const string CelebrantCode = "Celebrant";

        // Celebrant (funeral).
        public const int CelebrantForFuneralId = 2;

        // Couple.
        public const int CoupleId = 3;
        public const string CoupleCode = "Couple";

        // Organiser (marriage).
        public const int OrganiserForMarriageId = 4;
        public const string OrganiserCode = "Organiser";

        // Organiser (funeral).
        public const int OrganiserForFuneralId = 5;

        // Witness.
        public const int WitnessId = 6;
        public const string WitnessCode = "Witness";

        // Bridal party.
        public const int BridalPartyId = 7;
        public const string BridalPartyCode = "BridalParty";

        // Invited guest (marriage).
        public const int InvitedGuestForMarriageId = 8;
        public const string InvitedGuestCode = "InvitedGuest";

        // Deceased person.
        public const int DeceasedPersonId = 9;
        public const string DeceasedPersonCode = "Deceased";

        // Invited guest (funeral).
        public const int InvitedGuestForFuneralId = 10;

        // Other (marriage).
        public const int OtherForMarriageId = 11;
        public const string OtherCode = "Other";

        // Other (funeral).
        public const int OtherForFuneralId = 12;
    }
}