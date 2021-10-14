using System;
using Traveler.Identity.Domain.SeedWork;

namespace Traveler.Identity.Domain.Aggregates.JourneyerAggregate
{
    public class Journeyer : Entity, IAggregateRoot
    {
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool IsFirstLogin { get; private set; }

        protected Journeyer()
        {
        }

        public Journeyer(string email, string username, string password, bool isFirstLogin)
        {
            SetId();
            Email = email;
            Username = username;
            Password = password;
            IsFirstLogin = isFirstLogin;
        }

        public void SetLoggedOnce()
        {
            IsFirstLogin = true;
        }

        public void UpdateUserEmail(string email)
        {
            Email = email;
        }

        public void UpdateUserName(string username)
        {
            Username = username;
        }

        public void UpdatePassword(string password)
        {
            Password = password;
        }

        public bool CheckUserInfo(string email, string username)
        {
            return Email == email && Username == username;
        }
    }
}