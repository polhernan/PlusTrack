namespace PlusTrack.API.Infrastructure.Exceptions
{
    public class LicenseAtMaxException : Exception
    {
        public LicenseAtMaxException() : base("Some value of license is maxed and can't add more registers") { }
        public LicenseAtMaxException(string message) : base(message) { }
        public LicenseAtMaxException(string message, Exception innerException) : base(message, innerException) { }

    }
}
