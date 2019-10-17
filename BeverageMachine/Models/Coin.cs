namespace BeverageMachine.Models
{
    /// <summary>
    /// Монета
    /// </summary>
    public class Coin
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номинал
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Флаг блокировки
        /// </summary>
        public bool LockFlag { get; set; }

        /// <summary>
        /// Кол-во
        /// </summary>
        public uint Count { get; set; }


    }
}