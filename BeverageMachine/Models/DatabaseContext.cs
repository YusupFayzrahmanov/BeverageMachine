using System.Data.Entity;

namespace BeverageMachine.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() 
            : base("DefaultConnection")
        { }

        /// <summary>
        /// Книги
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public DbSet<Setting> Settings { get; set; }
    }
}