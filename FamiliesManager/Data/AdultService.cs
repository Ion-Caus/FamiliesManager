using System.Collections.Generic;
using System.Linq;
using FamiliesManager.Models;
using FamiliesManager.Persistence;

namespace FamiliesManager.Data
{
    public class AdultService : IAdultService
    {
        private FileContext fileContext;
        private readonly IList<Adult> adults;

        public AdultService(FileContext fileContext)
        {
            this.fileContext = fileContext;
            adults = fileContext.Adults;
        }
        
        public void Create(Adult adult)
        {
            adults.Add(adult);
            fileContext.SaveChanges();
        }

        public Adult Read(int id)
        {
            return adults.First(adult => adult.Id == id);
        }

        public IList<Adult> ReadAll()
        {
            fileContext.SaveChanges();
            return adults;
        }

        public void Update(Adult adult)
        {
            Adult toUpdate = adults.First(ad => ad.Id == adult.Id);
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.Age = adult.Age;
            toUpdate.Weight = adult.Weight;
            toUpdate.Height = adult.Height;
            toUpdate.HairColor = adult.HairColor;
            fileContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Adult toDelete = adults.First(ad => ad.Id == id);
            adults.Remove(toDelete);
            fileContext.SaveChanges();
        }
    }
}