namespace PlusTrack.API.Application.Commands.Users
{
    public class LoginUserCommand : IRequest<User>
    {


        public string Email { get; }
        public string Password { get; }


        public LoginUserCommand(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
    }
}
