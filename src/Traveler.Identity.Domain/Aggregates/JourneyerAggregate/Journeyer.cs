using Traveler.Identity.Domain.SeedWork;

namespace Traveler.Identity.Domain.Aggregates.JourneyerAggregate
{
    public class Journeyer : Entity, IAggregateRoot
    {
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        protected Journeyer()
        {
        }

        public Journeyer(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }

        public void UpdateUserEmail(string email)
        {
            Email = email;
        }

        public bool CheckUserInfo(string email, string username)
        {
            return Email == email && Username == username;
        }
    }
}