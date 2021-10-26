using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FamilyManager_WebApi.Models;

namespace FamilyManager_WebApi.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> _users;
        private readonly string _usersFile = "users.json";
        
        public InMemoryUserService()
        {
            if (!File.Exists(_usersFile))
            {
                GenerateDefaultUsers();
                WriteUsersToJson();
                
            }
            else
            {
                string content = File.ReadAllText(_usersFile);
                _users = JsonSerializer.Deserialize<List<User>>(content);
            }
        }
        
        private void WriteUsersToJson()
        {
            string todosAsJson = JsonSerializer.Serialize(_users);
            File.WriteAllText(_usersFile, todosAsJson);
        }

        private void GenerateDefaultUsers()
        {
            User[] defaultUsers =
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
            };
            _users = defaultUsers.ToList();
        }
        

        public bool ValidUsername(string username)
        {
            User first = _users.FirstOrDefault(user => user.Username.Equals(username));
            if (first != null)
            {
                throw new Exception("Username already taken.");
            }
            return true;
        }

        public User ValidateUser(string username, string password)
        {
            User first = _users.FirstOrDefault(user => user.Username.Equals(username));

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