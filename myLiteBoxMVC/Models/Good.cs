using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myLiteBoxMVC.Models
{
    public class Good
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ean { get; set; }
        public int GroupId { get; set; }
        public int UnitId { get; set; }
        public int NDSId { get; set; }
        public int DepartmentId { get; set; }
    }

    public class CreateGoodsModel
    {
        public int Id { get; set; }
        public string Ean { get; set; }

        [Required]
        public int GroupId { get; set; }
        public List<Group> groups { get; set; }
        public Group group { get; set; }

        [Required]
        public int UnitId { get; set; }
        public List<Unit> units { get; set; }
        public Unit unit { get; set; }

        [Required]
        public int NDSId { get; set; }
        public List<NDS> nds { get; set; }
        public NDS n { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public List<Department> departments { get; set; }
        public Department dep { get; set; }

        // SGood
        public string Name { get; set; }
        public string CreatorIdSGood { get; set; }
        public DateTime DateCreateSGood { get; set; }

        // RPrice
        public decimal price { get; set; }
        public string CreatorIdRPrice { get; set; }
        public DateTime DateCreateRPrice { get; set; }

        // GoodInf
        [Required]
        public int ManufacturerId { get; set; } //Производитель
        public List<Manufacturer> manufacturers { get; set; }
        public Manufacturer man { get; set; }

        public decimal fat { get; set; } // Процент жирности или наименьшее значение диапазона процента жирности
        public decimal mult { get; set; } // Количество(множитель для переменной mass)
        public decimal brutto { get; set; } // Масса/объем/количество
        public decimal energy { get; set; }// Энергетическая ценность
        public decimal proteins { get; set; } // Белки
        public decimal fats { get; set; } // Жиры
        public decimal carbohydrates { get; set; } // Углеводы
        public decimal vitamins { get; set; } // Витамины
        public string staff { get; set; } // Состав
        public string recomendations { get; set; } // Рекомендации по приготовлению
        public string storage { get; set; } // Условия хранения
        public string CreatorIdGoodInf { get; set; }
        public DateTime DateCreateGoodInf { get; set; }
        public string EditorIdGoodInf { get; set; }
        public DateTime DateEditGoodInf { get; set; }
    }

    public class ViewGoodsModel
    {
        public string group { get; set; }

        public string unit { get; set; }

        public int nds { get; set; }

        public string dep { get; set; }

        // SGood
        public string Name { get; set; }
        public DateTime DateCreateSGood { get; set; }

        // RPrice
        public decimal price { get; set; }
        public DateTime DateCreateRPrice { get; set; }

        
        public string m_Name { get; set; }
        public string adress { get; set; }
        
        // GoodInf
        public decimal fat { get; set; } // Процент жирности или наименьшее значение диапазона процента жирности
        public decimal mult { get; set; } // Количество(множитель для переменной mass)
        public decimal brutto { get; set; } // Масса/объем/количество
        public decimal energy { get; set; }// Энергетическая ценность
        public decimal proteins { get; set; } // Белки
        public decimal fats { get; set; } // Жиры
        public decimal carbohydrates { get; set; } // Углеводы
        public string vitamins { get; set; } // Витамины
        public string staff { get; set; } // Состав
        public string recomendations { get; set; } // Рекомендации по приготовлению
        public string storage { get; set; } // Условия хранения


        public string CreatorIdGoodInf { get; set; }
        public DateTime DateCreateGoodInf { get; set; }
        public string EditorIdGoodInf { get; set; }
        public DateTime DateEditGoodInf { get; set; }


    }

}