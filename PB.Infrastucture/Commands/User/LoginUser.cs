namespace PB.Infrastucture.Commands.User
{
    public class LoginUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}