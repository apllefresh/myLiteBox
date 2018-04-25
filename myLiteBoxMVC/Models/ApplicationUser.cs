using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace myLiteBoxMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Departments { get; set; }
        public string Name { get; set; }
        public ApplicationUser()
        {
        }
    }

    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class EditModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int Departments { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required]
        //public List<string> Roles { get; set; }

        public int SelectedRoleId { get; set; }
        public List<IdentityRole> roles { get; set; }
        public IdentityRole role { get; set; }

        //public  List<ApplicationRole> role;

        //public int SelectedRoleId { get; set; }

        //public IEnumerable<SelectListItem> Roles
        //{
        //    get { return new SelectList(role, "Id", "Name"); }
        //   // set { this.Roles = value; }
        //}
    }


    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public int Departments { get; set; }

        [Required]
        public int Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
       // [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }

    public class ListUser
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public int Departments { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Roles  { get; set; }
    }
}