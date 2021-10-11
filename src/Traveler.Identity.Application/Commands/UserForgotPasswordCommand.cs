namespace traveler.identity.api.application.Commands
{
    public class UserForgotPasswordCommand : Command
    {
        public string Email { get; set; }

        public UserForgotPasswordCommand(string email)
        {
            Email = email;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}