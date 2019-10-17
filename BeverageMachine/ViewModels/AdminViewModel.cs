using BeverageMachine.Models;
using System.Collections.Generic;

namespace BeverageMachine.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Drink Drink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Coin Coin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Drink> Drinks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Coin> Coins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}