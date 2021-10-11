namespace traveler.identity.api.application.Commands
{
    public class UserSignUpCommand : Command
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserSignUpCommand(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}