using System.Collections.Generic;
using System.Threading.Tasks;
using FamiliesManager.Models;

namespace FamiliesManager.Data
{
    public interface IAdultService
    {
        Task CreateAsync(Adult adult);
        Task<Adult> ReadAsync(int id);
        Task<IList<Adult>> ReadAllAsync();
        Task UpdateAsync(Adult adult);
        Task DeleteAsync(int id);
    }
}