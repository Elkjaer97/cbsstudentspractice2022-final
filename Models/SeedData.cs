using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using FinalPrac.Data; 
using System;
using System.Linq;

namespace FinalPrac.Models 
{
    public static class SeedData 
    {
        public static void Initialize (IServiceProvider serviceProvider)
        {
            using (var context = new DBContext(
                serviceProvider.GetRequiredService<DbContextOptions<DBContext>>()))
            {
                // Looks for any profile in db
                if (context.Profile.Any())
                {
                    return; // There are already a profile or more in db, and no seeds then
                }
                context.Profile.AddRange(
                    new Profile 
                    {
                        Name = "Jonas Elkjaer",
                        About = "I'm Jonas, 24 years of age. Lives in Copenhagen, at Nørrebronx 2200",
                        Email = "KEA@gmail.com",
                        Friends = 67,
                        ProfileImageName = "pictures/elephant.picture",  // only for testing purpose
                        UserCreated = DateTime.Parse("2022-6-5")
                    },
                    new Profile 
                    {
                        Name = "Kjeld",
                        About = "Software Developer at 3Shape",
                        Email = "kjeld@3shape.com",
                        Friends = 98,
                        ProfileImageName = "pictures/3shape.logo", // only for testing purpose
                        UserCreated = DateTime.Parse("2022-8-5")
                    }
                );
                context.SaveChanges();
            }
        }

    }
}

