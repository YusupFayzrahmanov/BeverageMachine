using System.ComponentModel.DataAnnotations;

namespace BeverageMachine.Models
{
    /// <summary>
    /// Напиток
    /// </summary>
    public class Drink
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Путь к изображению
        /// </summary>
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string ImagePath { get; set; }

        /// <summary>
        /// Кол-во напитков в аппарате
        /// </summary>
        public uint Count { get; set; }
    }
}