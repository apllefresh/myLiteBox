using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace myLiteBoxMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DepartmentId { get; set; }
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
        public string Name { get; set; }

        [Required]
        public string DepartmentId { get; set; }
        public List<Department> departments { get; set; }
        public Department dep { get; set; }

        public int SelectedRoleId { get; set; }
        public List<IdentityRole> roles { get; set; }
        public IdentityRole role { get; set; }
    }


    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DepartmentId { get; set; }
        public List<Department> departments { get; set; }
        public Department dep { get; set; }

        public string SelectedRoleId { get; set; }
        public List<IdentityRole> roles { get; set; }
        public IdentityRole role { get; set; }

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
        public string Departments { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Roles  { get; set; }
    }
}