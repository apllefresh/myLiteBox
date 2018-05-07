using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myLiteBoxMVC.Models
{
    public class Sertification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public DateTime dateReg { get; set; }
        public int ManufacturerId { get; set; }
    }

    public class EditSertificationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateEnd { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateReg { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        public List<Manufacturer> manufacturers { get; set; }
        public Manufacturer man { get; set; }
    }

    public class CreateSertificationModel
    {
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateEnd { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateReg { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        public List<Manufacturer> manufacturers { get; set; }
        public Manufacturer man { get; set; }
    }


    public class ListSertificationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string manufacturer { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateStart { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateEnd { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateReg { get; set; }

    }
}