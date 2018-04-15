using System;

namespace PB.Core.Models
{
    public class User
    {
        public int Id { get; protected set; }
        public string Username { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public User(string username, string email, string password, string salt)
        {
            SetUsername(username);
            SetEmail(email);
            SetPassword(password, salt);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw(new Exception("Email adress can't be empty"));
            }

            //regex

            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw(new Exception("Username can't be empty"));
            }

            Username = username;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw(new Exception("Lastname can't be empty"));
            }

            LastName = lastname;
            UpdatedAt = DateTime.UtcNow;
        }


        public void SetFirstName(string firstname)
        {
            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw(new Exception("Firstname can't be empty"));
            }

            FirstName = firstname;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw(new Exception("Password can't be empty"));
            }

            if (string.IsNullOrWhiteSpace(salt))
            {
                throw(new Exception("Salt can't be empty"));
            }

            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}