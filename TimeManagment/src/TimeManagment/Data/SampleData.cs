using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using TimeManagment.Models;

namespace TimeManagment.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();            //database used the term context instead of _db
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            
       

            if (!context.Tasks.Any()) {
                context.Tasks.AddRange(
                    new TodoTask() {Category= new Category { Name = "Math", User = stephen }, Description="Complete homework assignment 1",
                                    PriorityLevel =3,TimeEstimate=2,StartDate=new DateTime(2016,06,08) ,
                                    DueDate = new DateTime(2016,03,02), User= stephen
                    },

                    new TodoTask() {Category= new Category { Name = "Science", User=mike }, Description="Complete homework project 1",
                                    PriorityLevel =1,TimeEstimate=7,StartDate=new DateTime(2016,06,08) ,
                                    DueDate = new DateTime(2016,03,02),User = mike
                    } 
                  
                    );
                context.SaveChanges();

            }


        }



    }
}
