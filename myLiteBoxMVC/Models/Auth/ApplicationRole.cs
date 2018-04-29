using Microsoft.AspNet.Identity.EntityFramework;

namespace myLiteBoxMVC.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }

        public string Description { get; set; }
    }
    public class ListRoleModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class EditRoleModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class CreateRoleModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}