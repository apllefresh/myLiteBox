using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace myLiteBoxMVC.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("IdentityDb") { }

        //public DbSet<ApplicationUser> Users { get; set; }
        //public DbSet<ApplicationRole> Roles { get; set; }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}