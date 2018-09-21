using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myLiteBoxMVC.Models
{
    public class GoodInf
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GoodId { get; set; }
        public int ManufacturerId { get; set; } //Производитель
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
        public string CreatorId { get; set; }
        public DateTime DateCreate { get; set; }
        public string EditorId { get; set; }
        public DateTime DateEdit { get; set; }
    }
}