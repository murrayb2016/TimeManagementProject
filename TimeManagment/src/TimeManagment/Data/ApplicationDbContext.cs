using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeManagment.Models;

namespace TimeManagment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);



            builder.Entity<Category>()        //makes required
                     .HasMany(c => c.Tasks)
                     .WithOne(t => t.Category)
                     .IsRequired();


            builder.Entity<ApplicationUser>() 
                    .HasMany(au => au.Tasks)
                    .WithOne(t => t.User)
                    .IsRequired();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TodoTask> Tasks { get; set; }
      

    }
}
