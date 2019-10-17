using System.Data.Entity;

namespace BeverageMachine.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() 
            : base("DefaultConnection")
        { }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Drink> Drinks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Coin> Coins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Setting> Settings { get; set; }
    }
}