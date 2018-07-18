using AimsSchoolMaster.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AimsSchoolMaster.Context
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AdminUserProfile> UserProfile { get; set; }
        public DbSet<Course> Courses { get; set; }

        public SchoolContext()
            : base("SchoolContext")
        {
            //RepositoryFunctions = new PortalFunctions(this);
            //SetConfiguration();
            //InitializeDatabase();
        }

        public static SchoolContext Create()
        {
            return new SchoolContext();
        }

        /// <summary>
        /// Called when database model being created.
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder representing database model being created.</param>
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //	// Change the name of the table to be Users instead of AspNetUsers, etc.

        //	modelBuilder.Entity<UserProfile>().HasKey(d => d.Id);

        //	base.OnModelCreating(modelBuilder);
        //}
    }
}