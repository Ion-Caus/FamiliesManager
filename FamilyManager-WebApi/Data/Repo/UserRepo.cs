using System;
using System.Threading.Tasks;
using FamilyManager_WebApi.Models;
using FamilyManager_WebApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FamilyManager_WebApi.Data.Repo
{
    public class UserRepo : IUserService
    {
        private readonly AdultDbContext _dbContext;

        public UserRepo(AdultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User first = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username.Equals(username));

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