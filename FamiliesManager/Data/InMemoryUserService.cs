using System;
using System.Collections.Generic;
using System.Linq;
using FamiliesManager.Models;

namespace FamiliesManager.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;
        
        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    Username = "admin",
                    Password = "Admin1111",
                    Role = "Admin"
                },
                new User
                {
                    Username = "manager",
                    Password = "Manager1234",
                    Role = "Manager"
                },
                new User
                {
                    Username = "mike_c",
                    Password = "Mktoday1",
                    Role = "User"
                }
            }.ToList();
        }
        

        public bool ValidUsername(string username)
        {
            User first = users.FirstOrDefault(user => user.Username.Equals(username));
            if (first != null)
            {
                throw new Exception("Username already taken.");
            }
            return true;
        }

        public User ValidateUser(string username, string password)
        {
            User first = users.FirstOrDefault(user => user.Username.Equals(username));

            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}