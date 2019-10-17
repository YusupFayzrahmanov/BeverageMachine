using BeverageMachine.Models;
using System.Collections.Generic;

namespace BeverageMachine.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Drink> Drinks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Coin> Coins { get; set; }

        /// <summary>
        /// Покупатель
        /// </summary>
        public Buyer Buyer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}