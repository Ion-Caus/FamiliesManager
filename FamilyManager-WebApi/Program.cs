using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyManager_WebApi.Models;
using FamilyManager_WebApi.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FamilyManager_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (AdultDbContext dbContext = new AdultDbContext())
            {
                if (!dbContext.Adults.Any())
                {
                    SeedAdults(dbContext);
                }
                
                // if (!dbContext.Users.Any())
                // {
                //     SeedUsers(dbContext);
                // }
            }

            CreateHostBuilder(args).Build().Run();
        }

        private static void SeedAdults(DbContext dbContext)
        {
            Job chef = new()
            {
                JobTitle = "Chef",
                Salary = 50000

            };
            
            Job teacher = new()
            {
                JobTitle = "Teacher",
                Salary = 40000

            };
            
            Job policeman = new()
            {
                JobTitle = "Policeman",
                Salary = 35000

            };

            IList<Adult> adults =
                new List<Adult>()
                {
                    new()
                    {
                        FirstName = "Mike",
                        LastName = "Black",
                        Age = 29,
                        EyeColor = "Green",
                        HairColor = "Blond",
                        Height = 190,
                        Weight = 78,
                        Sex = "M",
                        
                        JobTitle = policeman,
                        
                    },
                    new()
                    {
                        FirstName = "Jake",
                        LastName = "Paul",
                        Age = 34,
                        EyeColor = "Green",
                        HairColor = "Brown",
                        Height = 185,
                        Weight = 78,
                        Sex = "M",
                        
                        JobTitle = chef,
                    },
                    new()
                    {
                        FirstName = "Mia",
                        LastName = "Johnson",
                        Age = 35,
                        EyeColor = "Brown",
                        HairColor = "Black",
                        Height = 170,
                        Weight = 65,
                        Sex = "F",
                        
                        JobTitle = teacher,
                    }
                };
            
            foreach (var adult in adults)
            {
                dbContext.Add(adult);
            }
            
            dbContext.SaveChanges();
        }
        
        private static void SeedUsers(DbContext dbContext)
        {
            
            IList<User> users =
                new List<User>()
                {
                    new()
                    {
                        Username = "admin",
                        Password = "admin",
                        Role = "Admin"

                    },
                    new()
                    {
                        Username = "manager",
                        Password = "manager",
                        Role = "Manager"
                    },
                    new()
                    {
                        Username = "mike_c",
                        Password = "12345",
                        Role = "User"
                    }
                };
            
            foreach (var user in users)
            {
                dbContext.Add(user);
            }
            
            dbContext.SaveChanges();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}