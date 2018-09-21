using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myLiteBoxMVC.Models
{
    public class RPrice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal price { get; set; }
        public int GoodId { get; set; }
        public string CreatorId { get; set; }
        public DateTime DateCreate { get; set; }
    }
}