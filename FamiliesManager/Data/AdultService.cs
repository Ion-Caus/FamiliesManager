using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamiliesManager.Models;
using FamiliesManager.Persistence;

namespace FamiliesManager.Data
{
    public class AdultService : IAdultService
    {
        private FileContext fileContext;
        private IList<Adult> adults;

        public AdultService(FileContext fileContext)
        {
            this.fileContext = fileContext;
            adults = fileContext.Adults;
        }
        
        public async Task CreateAsync(Adult adult)
        {
            int max;
            try
            {
                max = adults.Max(ad => ad.Id);
            }
            catch (InvalidOperationException)
            {
                max = 1;
            }
            
            adult.Id += ++max;
            adults.Add(adult);
            fileContext.SaveChanges();
        }

        public async Task<Adult> ReadAsync(int id)
        {
            return adults.First(adult => adult.Id == id);
        }

        public async Task<IList<Adult>> ReadAllAsync()
        {
            // return a copy
            return new List<Adult>(adults);
        }

        public async Task UpdateAsync(Adult adult)
        {
            Adult toUpdate = adults.First(ad => ad.Id == adult.Id);
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.Age = adult.Age;
            toUpdate.Weight = adult.Weight;
            toUpdate.Height = adult.Height;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.Sex = adult.Sex;
            toUpdate.JobTitle = toUpdate.JobTitle;
            fileContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            Adult toDelete = adults.First(ad => ad.Id == id);
            adults.Remove(toDelete);
            fileContext.SaveChanges();
        }
    }
}