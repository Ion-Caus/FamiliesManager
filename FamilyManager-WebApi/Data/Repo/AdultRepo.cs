using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyManager_WebApi.Models;
using FamilyManager_WebApi.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FamilyManager_WebApi.Data.Repo
{
    public class AdultRepo : IAdultService
    {
        private readonly AdultDbContext _dbContext;

        public AdultRepo(AdultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Adult> CreateAsync(Adult adult)
        {
            var added = await _dbContext.AddAsync(adult);
            await _dbContext.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<Adult> ReadAsync(int id)
        {
            try
            {
                return await _dbContext.Adults
                    .Include(adult => adult.JobTitle)
                    .FirstAsync(adult => adult.Id == id);
            }
            catch (Exception)
            {
                throw new Exception($"Did not find adult with id #{id}");
            }
        }


        public async Task<IList<Adult>> ReadAllAsync()
        {
            return await _dbContext.Adults.Include(adult => adult.JobTitle).ToListAsync();
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            try
            {
                _dbContext.Update(adult);
                await _dbContext.SaveChangesAsync();
                return adult;
            }
            catch (Exception)
            {
                throw new Exception($"Did not find adult with id #{adult.Id}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var toRemove = await _dbContext.Adults.FirstOrDefaultAsync(adult => adult.Id == id);
            if (toRemove != null)
            {
                _dbContext.Adults.Remove(toRemove);
                await _dbContext.SaveChangesAsync();
            }
            
        }
    }
}