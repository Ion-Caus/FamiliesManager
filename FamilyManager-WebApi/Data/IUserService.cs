using FamilyManager_WebApi.Models;

namespace FamilyManager_WebApi.Data
{
    public interface IUserService
    {
        bool ValidUsername(string username);
        User ValidateUser(string username, string password);
    }
}