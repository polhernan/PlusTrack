namespace PlusTrack.API.Infrastructure.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base("The provided password was incorrect") { }
        public WrongPasswordException(string message) : base(message) { }
    }
}
