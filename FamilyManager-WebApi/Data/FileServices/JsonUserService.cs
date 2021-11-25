using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FamilyManager_WebApi.Models;

namespace FamilyManager_WebApi.Data.FileServices
{
    public class JsonUserService : IUserService
    {
        private List<User> _users;
        private readonly string _usersFile = "users.json";
        
        public JsonUserService()
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
            string todosAsJson = JsonSerializer.Serialize(_users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
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

        public async Task<User> ValidateUserAsync(string username, string password)
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