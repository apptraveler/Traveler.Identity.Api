namespace traveler.identity.api.application.Commands
{
    public class UserSignInCommand : Command
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }

        public UserSignInCommand(string usernameOrEmail, string password)
        {
            UsernameOrEmail = usernameOrEmail;
            Password = password;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}