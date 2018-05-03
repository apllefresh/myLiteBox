using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace myLiteBoxMVC.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("IdentityDb") { }

        public DbSet<Department> Departments { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }
        //public DbSet<ApplicationRole> Roles { get; set; }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public System.Data.Entity.DbSet<myLiteBoxMVC.Models.Unit> Units { get; set; }

        public System.Data.Entity.DbSet<myLiteBoxMVC.Models.NDS> NDS { get; set; }

        public System.Data.Entity.DbSet<myLiteBoxMVC.Models.Manufacturer> Manufacturers { get; set; }
    }
}