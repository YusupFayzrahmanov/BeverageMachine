using System.ComponentModel.DataAnnotations;

namespace BeverageMachine.Models
{
    /// <summary>
    /// Настройки
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование параметра
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }
    }
}