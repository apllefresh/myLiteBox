using Microsoft.AspNet.Identity.EntityFramework;

namespace myLiteBoxMVC.Models
{


    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }
        public ApplicationUser()
        {
        }
    }
}