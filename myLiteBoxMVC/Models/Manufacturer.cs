using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myLiteBoxMVC.Models
{
    public class Manufacturer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(12)]
        public string INN { get; set; }
        public string Country { get; set; }
        public string Subject { get; set; }
        public string Distrinct { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        [MaxLength(6)]
        public string ZipCode { get; set; }

        [DefaultValue("true")]
        public bool isActive { get; set; }
    }
}