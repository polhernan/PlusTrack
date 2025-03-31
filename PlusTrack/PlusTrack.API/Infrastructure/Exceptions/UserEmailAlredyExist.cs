namespace PlusTrack.API.Infrastructure.Exceptions
{
    public class UserEmailAlredyExist : Exception
    {
        public UserEmailAlredyExist() : base("User with this email alredy exist") { }
    }
}
