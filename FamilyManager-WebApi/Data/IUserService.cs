using System.Threading.Tasks;
using FamilyManager_WebApi.Models;

namespace FamilyManager_WebApi.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
    }
}