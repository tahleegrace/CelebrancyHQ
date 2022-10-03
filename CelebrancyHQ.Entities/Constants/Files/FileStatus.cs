namespace CelebrancyHQ.Entities.Constants.Files
{
    /// <summary>
    /// Represents the statuses a file can have.
    /// </summary>
    public static class FileStatus
    {
        public const string Pending = "Pending";
        public const string AwaitingVirusScan = "AwaitingVirusScan";
        public const string VirusScanPassed = "VirusScanPassed";
        public const string VirusScanFailed = "VirusScanFailed";
    }
}