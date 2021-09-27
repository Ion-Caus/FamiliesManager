using System.Collections.Generic;
using FamiliesManager.Models;

namespace FamiliesManager.Data
{
    public interface IAdultService
    {
        void Create(Adult adult);
        Adult Read(int id);
        IList<Adult> ReadAll();
        void Update(Adult adult);
        void Delete(int id);
    }
}