using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManager_WebApi.Models;

namespace FamilyManager_WebApi.Data
{
    public interface IAdultService
    {
        Task<Adult> CreateAsync(Adult adult);
        Task<Adult> ReadAsync(int id);
        Task<IList<Adult>> ReadAllAsync();
        Task<Adult> UpdateAsync(Adult adult);
        Task DeleteAsync(int id);
    }
}