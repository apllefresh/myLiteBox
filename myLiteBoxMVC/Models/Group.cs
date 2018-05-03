using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myLiteBoxMVC.Models
{
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        [DefaultValue("true")]
        public bool isActive { get; set; }
    }

    public class EditGroupModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public List<Department> departments { get; set; }
        public Department dep { get; set; }

        public bool isActive { get; set; }
    }

    public class CreateGroupModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public List<Department> departments { get; set; }
        public Department dep { get; set; }
    }


    public class ListGroupModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }
       
    }
}