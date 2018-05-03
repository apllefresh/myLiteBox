using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace myLiteBoxMVC.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isSale { get; set; }
        [DefaultValue("true")]
        public bool isActive { get; set; }
    }
    public class CreateDepartmentModel
    {
        public string Name { get; set; }
        public bool isSale { get; set; }
    }
}