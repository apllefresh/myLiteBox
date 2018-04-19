using System;
using System.ComponentModel.DataAnnotations;

namespace myLiteBoxMVC.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class EditModel
    {
        public int Year { get; set; }
    }
}