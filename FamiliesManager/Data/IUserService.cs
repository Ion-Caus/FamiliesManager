using FamiliesManager.Models;

namespace FamiliesManager.Data
{
    public interface IUserService
    {
        bool ValidUsername(string username);
        User ValidateUser(string username, string password);
    }
}