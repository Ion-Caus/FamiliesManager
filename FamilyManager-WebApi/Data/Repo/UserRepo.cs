using System.Threading.Tasks;
using FamilyManager_WebApi.Models;

namespace FamilyManager_WebApi.Data.Repo
{
    public class UserRepo : IUserService
    {
        public Task<User> ValidateUserAsync(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}