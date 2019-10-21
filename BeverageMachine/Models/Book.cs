using System;
using System.ComponentModel.DataAnnotations;

namespace BeverageMachine.Models
{
    /// <summary>
    /// Книга
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Издательство
        /// </summary>
        public string PublishingHouse { get; set; }

        /// <summary>
        /// Краткое описание
        /// </summary>
        [MaxLength(100)]
        public string Description { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public DateTime Year { get; set; }


    }
}