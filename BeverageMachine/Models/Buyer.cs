using System.Collections.Generic;

namespace BeverageMachine.Models
{
    public class Buyer
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public List<Drink> Drinks { get; set; } = new List<Drink>();
    }
}