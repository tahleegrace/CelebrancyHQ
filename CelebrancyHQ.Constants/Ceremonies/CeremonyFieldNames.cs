﻿namespace CelebrancyHQ.Constants.Ceremonies
{
    /// <summary>
    /// Stores a list of field names for ceremonies (used for checking permissions).
    /// </summary>
    public static class CeremonyFieldNames
    {
        public const string KeyDetails = "KeyDetails";
        public const string Dates = "Dates";
        public const string Participants = "Participants";
        public const string ServiceProviders = "ServiceProviders";
        public const string Meetings = "Meetings";

        public static readonly IReadOnlyList<string> FieldNames = new List<string>() { KeyDetails, Dates, Participants, ServiceProviders, Meetings };
    }
}